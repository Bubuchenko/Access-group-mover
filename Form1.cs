using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MWControlSuite;
using CookComputing.XmlRpc;
using System.Net;
using System.Collections;
using System.Threading;

namespace AD_browser
{
    public partial class Form1 : Form
    {
        MWTreeView treeView1;
        public const string LDAP_ADDR = "LDAP://mco.local";
        public string USERNAME;
        public string PASSWORD;
        bool CheckIntegrity { get; set; }
        bool FirstLoad { get; set; }
        bool AutoRefreshAfterExecution { get; set; }

        List<Machine> MachineList;
        Hashtable AccessGroups;

        public Form1()
        {
            CheckIntegrity = true;
            AutoRefreshAfterExecution = true;
            FirstLoad = true;
            MachineList = new List<Machine>();
            AccessGroups = new Hashtable();

            InitializeComponent();
            CreateTreeView();
        }

        private void CreateTreeView()
        {
            if (treeView1 != null)
                this.groupBox1.Controls.Remove(treeView1);

            treeView1 = new MWTreeView();
            treeView1.Width = treetemplate.Width;
            treeView1.Height = treetemplate.Height;
            treeView1.Location = new Point(12, 18);
            this.groupBox1.Controls.Add(treeView1);
            treeView1.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(AddNodeDoubleByClick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshBtn.Enabled = false;
            LoadSystemsClickEvent();
            refreshBtn.Enabled = false;
        }

        private void LoadSystemsClickEvent()
        {
            progressBar1.Visible = true;
            loadingStatuslabel.Visible = true;
            progressBar1.BringToFront();
            refreshBtn.Enabled = false;

            CreateTreeView();

            if (FirstLoad)
            {
                Thread t = new Thread(new ThreadStart(ReloadComputersFull));
                t.Start();
                FirstLoad = false;
            }
            else
            {
                Thread t = new Thread(new ThreadStart(ReloadComputersAccessgroups));
                t.Start();
            }
            refreshBtn.Enabled = true;
        }


        void ReloadComputersAccessgroups()
        {
            GetAndSetMachineAccessGroups();
            AddMachinesToTreeview();
        }

        void ReloadComputersFull()
        {
            GetComputers();
            GetAndSetMachineAccessGroups();
            AddMachinesToTreeview();
        }

        public void AddMachinesToTreeview()
        {
            List<Machine> OUs = MachineList.DistinctBy(f => f.OU).ToList().OrderBy(f => f.OU).ToList();

            this.Invoke((MethodInvoker)delegate
                {
                    progressBar1.Visible = false;
                    loadingStatuslabel.Visible = false;
                });

            for (int i = 0; i < OUs.Count; i++)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    treeView1.Nodes.Add(OUs[i].OU);
                });
            }


            foreach (Machine m in MachineList.OrderBy(f => f.Name).ToList())
            {
                this.Invoke((MethodInvoker)delegate
                {
                    foreach (TreeNode node in treeView1.Nodes)
                    {
                        if (m.OU == node.Text)
                        {
                            try
                            {
                                node.Nodes.Add(string.Format("{0} : [{1}]", m.Name, AccessGroups[m.AccessGroup].ToString()));
                            }
                            catch { }
                        }
                    }
                });
            }
        }


        [XmlRpcUrl("https://qmanage.msanet.nl/admin/rpc")]
        public interface iSearchAction : IXmlRpcProxy
        {
            [XmlRpcMethod("perform_actions")]
            XmlRpcStruct[] perform_actions(XmlRpcStruct[] struc);
        }

        public void GetComputers()
        {
            this.Invoke((MethodInvoker)delegate
            {
                loadingStatuslabel.Text = "Retrieving systems from active directory...";
            });

            DirectoryEntry entry = new DirectoryEntry(LDAP_ADDR);
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            mySearcher.Filter = ("(objectClass=computer)");
            mySearcher.SizeLimit = 0;
            mySearcher.PageSize = 1000;

            foreach (SearchResult resEnt in mySearcher.FindAll())
            {
                string ComputerName = resEnt.GetDirectoryEntry().Properties["Name"].Value.ToString();
                string ou = resEnt.GetDirectoryEntry().Parent.Properties["Name"].Value.ToString();

                MachineList.Add(new Machine { Name = ComputerName, OU = ou, AccessGroup = "UNKNOWN"});
            }

            mySearcher.Dispose();
            entry.Dispose();
        }

        public void GetAndSetMachineAccessGroups()
        {
            XmlRpcStruct[] actions = new XmlRpcStruct[1];
            XmlRpcStruct action = new XmlRpcStruct();
            action.Add("name", "registrations.machines.list");
            actions[0] = action;

            iSearchAction proxy = XmlRpcProxyGen.Create<iSearchAction>();
            proxy.Credentials = new NetworkCredential(USERNAME, PASSWORD);

            XmlRpcStruct[] response = proxy.perform_actions(actions);
            dynamic result = response[0]["result"];

            this.Invoke((MethodInvoker)delegate
            {
                loadingStatuslabel.Text = "Retrieving machine information from Qmanage...";
            });

            for (int i = 0; i < result.Length; i++)
            {
                string ID = result[i]["id"].ToString();
                string machineName = result[i]["hostname"].ToString();
                string accessGroup = result[i]["accessgroup"].ToString();

                //Sanitize the name
                if (machineName.Contains("mco.local"))
                    machineName = machineName.Replace(".mco.local", "");

                Machine machine = MachineList.Where(f => f.Name == machineName).FirstOrDefault();

                if (machine == null)
                    continue;

                    machine.AccessGroup = accessGroup;
                machine.ID = ID;
            }


            if (CheckIntegrity)
            {
                MachineList.RemoveAll(f => f.AccessGroup == "UNKNOWN");
            }
        }

        public void GetAccessgroups()
        {
            XmlRpcStruct[] actions = new XmlRpcStruct[1];
            XmlRpcStruct action = new XmlRpcStruct();
            action.Add("name", "network.accessgroups.list");
            actions[0] = action;

            iSearchAction proxy = XmlRpcProxyGen.Create<iSearchAction>();
            proxy.Credentials = new NetworkCredential(USERNAME, PASSWORD);

            XmlRpcStruct[] response = proxy.perform_actions(actions);
            dynamic result = response[0]["result"];

            for (int i = 0; i < result.Length; i++)
            {
                string accessgroupId = result[i]["id"].ToString();
                string accessgroupName = result[i]["name"].ToString();
                AccessGroups.Add(accessgroupId, accessgroupName);

                accessgroupSelection.Items.Add(accessgroupName);
            }
        }

        public class Machine
        {
            public string Name { get; set; }
            public string OU {  get; set; }
            public string AccessGroup { get; set; }
            public string ID { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buildLabel.Text = "Build: " + Properties.Resources.BuildDate;
            LoadSystemsClickEvent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            addSelectedNodesToList();
        }

        private void addSelectedNodesToList()
        {
            foreach (DictionaryEntry item in treeView1.SelNodes)
            {
                MWTreeNodeWrapper node = (MWTreeNodeWrapper)item.Value;

                //If a whole OU gets added, add all it's children
                if (node.Node.Level == 0)
                {
                    foreach(TreeNode n in node.Node.Nodes)
                    {
                        if(listbox1.Items.Contains(n.Text))
                        {
                            continue;
                        }

                        listbox1.Items.Add(n.Text);
                    }
                    continue;
                }

                if (listbox1.Items.Contains(node.Node.Text))
                {
                    MessageBox.Show("Item is already added!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                listbox1.Items.Add(node.Node.Text);
            }
        }

        private void AddNodeDoubleByClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            addSelectedNodesToList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listbox1.SelectedItems.Count > 0)
            {

                //Casting to a list first because the compiler does not like me actively removing items from a collection it's enumerating through
                List<string> items = listbox1.SelectedItems.Cast<string>().ToList();

                foreach (string selectedItem in items)
                {
                    listbox1.Items.Remove(selectedItem);
                }
            }
        }

        private void PerformAccessGroupMove(List<Machine> machinelist, string accessgroup)
        {
            XmlRpcStruct[] actions = new XmlRpcStruct[machinelist.Count];
            
            for (int i = 0; i < machinelist.Count; i++)
            {
                XmlRpcStruct action = new XmlRpcStruct();
                XmlRpcStruct filter = new XmlRpcStruct();

                action.Add("name", "registrations.machines.edit");
                action.Add("args", filter);

                filter.Add("id", machinelist[i].ID);
                filter.Add("accessgroup", AccessGroups.Keys.OfType<string>().FirstOrDefault(f =>  (string)AccessGroups[f] == accessgroup));

                actions[i] = action;
            }

            iSearchAction proxy = XmlRpcProxyGen.Create<iSearchAction>();
            proxy.Credentials = new NetworkCredential(USERNAME, PASSWORD);

            XmlRpcStruct[] response = proxy.perform_actions(actions);
            dynamic result = response[0]["result"];

            ConfirmChanges(accessgroup);
            executeBtn.Enabled = true;

        }

        
        private void ConfirmChanges(string accessgroup)
        {
            int count = listbox1.Items.Count;
            string[] processedItems = listbox1.Items.Cast<string>().ToArray();
            listbox1.Items.Clear();

            for(int i = 0; i < count; i++)
            {
                string computername = processedItems[i].ToString().Split(':')[0].TrimEnd();
                Machine m = MachineList.FirstOrDefault(f => f.Name == computername);
                m.AccessGroup = accessgroup;
                listbox1.Items.Add(string.Format("{0} : [{1}]", m.Name, m.AccessGroup));
            }


            if(AutoRefreshAfterExecution)
                LoadSystemsClickEvent();
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            if (listbox1.Items.Count < 1)
            {
                MessageBox.Show("Select at least one machine", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (accessgroupSelection.SelectedItem == null)
            {
                MessageBox.Show("Select an access group", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            executeBtn.Enabled = false;

            DialogResult dr = MessageBox.Show(string.Format("{0} machines will be moved to the '{1}' access group, are you absolutely sure?",
                listbox1.Items.Count, accessgroupSelection.SelectedItem.ToString()), "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dr == System.Windows.Forms.DialogResult.No)
                return;

            List<Machine> selectedMachines = new List<Machine>();

            foreach (string machine in listbox1.Items)
            {
                string computername = machine.Split(':')[0].TrimEnd();

                selectedMachines.Add(MachineList.FirstOrDefault(f => f.Name == computername));
            }

            PerformAccessGroupMove(selectedMachines, accessgroupSelection.SelectedItem.ToString());

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listbox1.Items.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }


    }

    public static class ExtensionMethods
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
        (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }

}
