using System;
using System.Linq;
using System.Windows.Forms;
namespace Store_System
{
    public partial class Form1 : Form
    {
        Store_SystemEntities context = new Store_SystemEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            RefreshData();
            RefreshProducts();
            RefreshSuppliers();
            RefreshCustomers();
            RefreshImports();
            RefreshExports();
            RefreshTransferes();
        }
        #region Refresh Data
        private void RefreshData()
        {
            idtxt.Text = Addresstxt.Text = Managertxt.Text = "";
            listBox1.Items.Clear();
            var stores = context.Stores;
            foreach (var store in stores)
            {
                listBox1.Items.Add(store.id);
            }
        }

        private void RefreshProducts()
        {
            ProductNametxt.Text = ProductUnittxt.Text = "";
            listBox2.Items.Clear();
            var products = context.Products;
            foreach (var product in products)
            {
                listBox2.Items.Add(product.id);
            }
        }
        private void RefreshSuppliers()
        {
            SupplierIdtxt.Text = SupplierNametxt.Text = SupplierEmailtxt.Text = SupplierFaxtxt.Text =
                                    SupplierMobiletxt.Text = SupplierWebsitetxt.Text = "";
            listBox3.Items.Clear();
            var suppliers = context.Suppliers;
            foreach (var supplier in suppliers)
            {
                listBox3.Items.Add(supplier.id);
            }
        }
        private void RefreshCustomers()
        {
            CustomerIdtxt.Text = CustomerNametxt.Text = CustomerEmailtxt.Text = CustomerFaxtxt.Text =
                                    CustomerMobiletxt.Text = CustomerWebsitetxt.Text = "";
            listBox4.Items.Clear();
            var customers = context.Customers;
            foreach (var customer in customers)
            {
                listBox4.Items.Add(customer.id);
            }
        }

        private void RefreshImports()
        {

            textBox1.Text = textBox2.Text = textBox3.Text = "";
            listBox5.Items.Clear();
            var imports = context.imports;
            foreach (var import in imports)
            {
                listBox5.Items.Add(import.id);
            }
            ProductIdcbox1.Items.Clear();
            var products = context.Products;
            foreach (var product in products)
            {
                ProductIdcbox1.Items.Add(product.id);
            }
            StoreIdcbox1.Items.Clear();
            var stores = context.Stores;
            foreach (var store in stores)
            {
                StoreIdcbox1.Items.Add(store.id);
            }
            SupplierIdcbox1.Items.Clear();
            var suppliers = context.Suppliers;
            foreach (var supplier in suppliers)
            {
                SupplierIdcbox1.Items.Add(supplier.id);
            }
        }
        private void RefreshExports()
        {
            textBox5.Text = textBox6.Text = textBox7.Text = "";

            listBox6.Items.Clear();
            var exports = context.exports;
            foreach (var export in exports)
            {
                listBox6.Items.Add(export.id);
            }
            ProductIdcbox2.Items.Clear();
            var products = context.Products;
            foreach (var product in products)
            {
                ProductIdcbox2.Items.Add(product.id);
            }
            StoreIdcbox2.Items.Clear();
            var stores = context.Stores;
            foreach (var store in stores)
            {
                StoreIdcbox2.Items.Add(store.id);
            }
            CustomerIdcbox2.Items.Clear();
            var customers = context.Customers;
            foreach (var customer in customers)
            {
                CustomerIdcbox2.Items.Add(customer.id);
            }
        }

        private void RefreshTransferes()
        {

            textBox8.Text = textBox9.Text = textBox10.Text = "";
            listBox7.Items.Clear();
            var imports = context.imports;
            foreach (var import in imports)
            {
                listBox7.Items.Add(import.id);
            }
            ToStoreIdcbox3.Items.Clear();
            var stores = context.Stores;
            foreach (var store in stores)
            {
                ToStoreIdcbox3.Items.Add(store.id);
            }
        }
        #endregion

        #region Store
        private void AddStorebtn_Click(object sender, System.EventArgs e)
        {
            Store store = new Store();
            // store.id = Int32.Parse(idtxt.Text);
            store.address = Addresstxt.Text;
            store.manager = Managertxt.Text;
            context.Stores.Add(store);
            context.SaveChanges();
            RefreshData();
            MessageBox.Show("Store has been Added successfuly");

        }

        private void EditStorebtn_Click(object sender, System.EventArgs e)
        {
            int id = int.Parse(listBox1.Text);
            Store store = context.Stores.Find(id);
            if (store != null)
            {
                store.address = Addresstxt.Text;
                store.manager = Managertxt.Text;
                context.SaveChanges();
                RefreshData();
                MessageBox.Show("Store has been updated successfuly");
            }
            else
            {
                MessageBox.Show("invalid id");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int ID = int.Parse(listBox1.Text);
            Store store = context.Stores.Find(ID);
            if (store != null)
            {
                idtxt.Text = store.id.ToString();
                Addresstxt.Text = store.address;
                Managertxt.Text = store.manager;
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }
        #endregion

        #region Product
        private void listBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int ID = int.Parse(listBox2.Text);
            Product product = context.Products.Find(ID);
            if (product != null)
            {
                productIdtxt.Text = product.id.ToString();
                ProductNametxt.Text = product.name;
                ProductUnittxt.Text = product.unit;
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }

        private void AddProductbtn_Click(object sender, System.EventArgs e)
        {
            Product product = new Product();
            // store.id = Int32.Parse(idtxt.Text);
            product.name = ProductNametxt.Text;
            product.unit = ProductUnittxt.Text;
            context.Products.Add(product);
            context.SaveChanges();
            // RefreshData();
            RefreshProducts();
            MessageBox.Show("Product has been Added successfuly");

        }

        private void EditProductbtn_Click(object sender, System.EventArgs e)
        {
            int id = int.Parse(listBox2.Text);
            Product product = context.Products.Find(id);
            if (product != null)
            {
                product.name = ProductNametxt.Text;
                product.unit = ProductUnittxt.Text;
                context.SaveChanges();
                // RefreshData();
                RefreshProducts();
                MessageBox.Show("Product has been updated successfuly");
            }
            else
            {
                MessageBox.Show("invalid id");
            }
        }
        #endregion

        #region Supplier
        private void listBox3_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int ID = int.Parse(listBox3.Text);
            Supplier supplier = context.Suppliers.Find(ID);
            if (supplier != null)
            {
                SupplierIdtxt.Text = supplier.id.ToString();
                SupplierNametxt.Text = supplier.name;
                SupplierEmailtxt.Text = supplier.email;
                SupplierMobiletxt.Text = supplier.mobile;
                SupplierFaxtxt.Text = supplier.fax;
                SupplierWebsitetxt.Text = supplier.website;
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }

        }

        private void AddSupplierbtn_Click(object sender, System.EventArgs e)
        {
            Supplier supplier = new Supplier();
            supplier.name = SupplierNametxt.Text;
            supplier.email = SupplierEmailtxt.Text;
            supplier.mobile = SupplierMobiletxt.Text;
            supplier.fax = SupplierFaxtxt.Text;
            supplier.website = SupplierWebsitetxt.Text;

            context.Suppliers.Add(supplier);
            context.SaveChanges();
            RefreshSuppliers();
            MessageBox.Show("Supplier has been Added successfuly");

        }

        private void EditSupplierbtn_Click(object sender, System.EventArgs e)
        {
            int id = int.Parse(listBox3.Text);
            Supplier supplier = context.Suppliers.Find(id);
            if (supplier != null)
            {
                supplier.name = SupplierNametxt.Text;
                supplier.email = SupplierEmailtxt.Text;
                supplier.mobile = SupplierMobiletxt.Text;
                supplier.fax = SupplierFaxtxt.Text;
                supplier.website = SupplierWebsitetxt.Text;
                context.SaveChanges();
                RefreshSuppliers();
                MessageBox.Show("Supplier has been updated successfuly");
            }
            else
            {
                MessageBox.Show("invalid id");
            }
        }
        #endregion

        #region Customer
        private void listBox4_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int ID = int.Parse(listBox4.Text);
            Customer customer = context.Customers.Find(ID);
            if (customer != null)
            {
                CustomerIdtxt.Text = customer.id.ToString();
                CustomerNametxt.Text = customer.name;
                CustomerEmailtxt.Text = customer.email;
                CustomerMobiletxt.Text = customer.mobile;
                CustomerFaxtxt.Text = customer.fax;
                CustomerWebsitetxt.Text = customer.website;
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }


        }

        private void AddCustomerbtn_Click(object sender, System.EventArgs e)
        {
            Customer customer = new Customer();
            customer.name = CustomerNametxt.Text;
            customer.email = CustomerEmailtxt.Text;
            customer.mobile = CustomerMobiletxt.Text;
            customer.fax = CustomerFaxtxt.Text;
            customer.website = CustomerWebsitetxt.Text;

            context.Customers.Add(customer);
            context.SaveChanges();
            RefreshCustomers();
            MessageBox.Show("Customer has been Added successfuly");
        }

        private void EditCustomerbtn_Click(object sender, System.EventArgs e)
        {
            int id = int.Parse(listBox4.Text);
            Customer customer = context.Customers.Find(id);
            if (customer != null)
            {
                customer.name = CustomerNametxt.Text;
                customer.email = CustomerEmailtxt.Text;
                customer.mobile = CustomerMobiletxt.Text;
                customer.fax = CustomerFaxtxt.Text;
                customer.website = CustomerWebsitetxt.Text;
                context.SaveChanges();
                RefreshCustomers();
                MessageBox.Show("Customer has been updated successfuly");
            }
            else
            {
                MessageBox.Show("invalid id");
            }
        }
        #endregion

        #region Imports
        private void Createbtn_Click(object sender, System.EventArgs e)
        {
            //Add imports
            import import = new import();
            import.Date = new DateTime(ImportDatePicker.Value.Ticks);
            import.Production_Date = new DateTime(ImportProductionDatePicker.Value.Ticks);
            import.Expiration_Date = new DateTime(ImportExpirationDatePicker.Value.Ticks);
            import.Quantity = int.Parse(ImportQuantitytxt.Text);

            Product product = context.Products.Find(int.Parse(ProductIdcbox1.Text));
            import.Product = product;
            Store store = context.Stores.Find(int.Parse(StoreIdcbox1.Text));
            import.Store = store;
            Supplier supplier = context.Suppliers.Find(int.Parse(SupplierIdcbox1.Text));
            import.Supplier = supplier;

            context.imports.Add(import);
            //Add Product to store 
            product.Stores.Add(store);

            context.SaveChanges();
            MessageBox.Show("Import has been Added successfuly");
            RefreshImports();

        }
        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(listBox5.Text);
            import import = context.imports.Find(ID);
            if (import != null)
            {
                ProductIdcbox1.Text = import.Product_id.ToString();
                StoreIdcbox1.Text = import.Storage_id.ToString();
                SupplierIdcbox1.Text = import.Supplier_id.ToString();
                ImportQuantitytxt.Text = import.Quantity.ToString();
                ImportDatePicker.Text = import.Date.ToString();
                ImportProductionDatePicker.Text = import.Production_Date.ToString();
                ImportExpirationDatePicker.Text = import.Expiration_Date.ToString();
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }

        }
        private void UpdateImportbtn_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(listBox5.Text);
            import import = context.imports.Find(ID);
            if (import != null)
            {
                import.Date = new DateTime(ImportDatePicker.Value.Ticks);
                import.Production_Date = new DateTime(ImportProductionDatePicker.Value.Ticks);
                import.Expiration_Date = new DateTime(ImportExpirationDatePicker.Value.Ticks);
                import.Quantity = int.Parse(ImportQuantitytxt.Text);
                Product product = context.Products.Find(int.Parse(ProductIdcbox1.Text));
                import.Product = product;
                Store store = context.Stores.Find(int.Parse(StoreIdcbox1.Text));
                import.Store = store;
                Supplier supplier = context.Suppliers.Find(int.Parse(SupplierIdcbox1.Text));
                import.Supplier = supplier;
                context.SaveChanges();
                RefreshCustomers();
                MessageBox.Show("Import has been updated successfuly");
            }
            else
            {
                MessageBox.Show("invalid id");
            }
            RefreshImports();
        }
        private void ProductIdcbox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productID = int.Parse(ProductIdcbox1.Text);
            string name = context.Products.Find(productID).name;
            textBox1.Text = name;
        }

        private void StoreIdcbox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int storeID = int.Parse(StoreIdcbox1.Text);
            string address = context.Stores.Find(storeID).address;
            textBox2.Text = address;
        }

        private void SupplierIdcbox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int supplierID = int.Parse(SupplierIdcbox1.Text);
            string name = context.Suppliers.Find(supplierID).name;
            textBox3.Text = name;
        }
        #endregion

        #region Exports
        private void CreateExportbtn_Click(object sender, EventArgs e)
        {
            int count = 0;
            export export = new export();
            export.Date = new DateTime(ExportDatePicker.Value.Ticks);
            export.Quantity = int.Parse(ExportQuantitytxt.Text);
            Product product = context.Products.Find(int.Parse(ProductIdcbox2.Text));
            export.Product = product;
            Store store = context.Stores.Find(int.Parse(StoreIdcbox2.Text));
            export.Store = store;
            Customer customer = context.Customers.Find(int.Parse(CustomerIdcbox2.Text));
            export.Customer = customer;
            count = getProductCount(export.Product.id, export.Store.id);
            if (count >= export.Quantity)
            {
                context.exports.Add(export);
                MessageBox.Show("Export has been Added successfuly");
            }
            else if (count > 0)
            {
                MessageBox.Show($"There are only {count}");

            }
            else// if (count == 0)
            {
                MessageBox.Show("production is out of stock");
            }
            context.SaveChanges();
            RefreshExports();

        }
        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(listBox6.Text);
            export export = context.exports.Find(ID);
            if (export != null)
            {
                ProductIdcbox2.Text = export.Product_id.ToString();
                StoreIdcbox2.Text = export.Storage_id.ToString();
                CustomerIdcbox2.Text = export.Customer_id.ToString();
                ExportQuantitytxt.Text = export.Quantity.ToString();
                ExportDatePicker.Text = export.Date.ToString();
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }

        }
        private void UpdateExportbtn_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(listBox6.Text);
            export export = context.exports.Find(ID);
            if (export != null)
            {
                export.Date = new DateTime(ExportDatePicker.Value.Ticks);
                export.Quantity = int.Parse(ExportQuantitytxt.Text);
                Product product = context.Products.Find(int.Parse(ProductIdcbox2.Text));
                export.Product = product;
                Store store = context.Stores.Find(int.Parse(StoreIdcbox2.Text));
                export.Store = store;
                Customer customer = context.Customers.Find(int.Parse(CustomerIdcbox2.Text));
                export.Customer = customer;
                context.SaveChanges();
                RefreshCustomers();
                MessageBox.Show("Import has been updated successfuly");
            }
            else
            {
                MessageBox.Show("invalid id");
            }
            RefreshExports();
        }
        private void ProductIdcbox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productID = int.Parse(ProductIdcbox2.Text);
            string name = context.Products.Find(productID).name;
            textBox7.Text = name;
        }

        private void StoreIdcbox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int storeID = int.Parse(StoreIdcbox2.Text);
            string address = context.Stores.Find(storeID).address;
            textBox6.Text = address;

        }

        private void CustomerIdcbox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int customerID = int.Parse(CustomerIdcbox2.Text);
            string name = context.Customers.Find(customerID).name;
            textBox5.Text = name;
        }
        #endregion


        #region Transfere

        private void Transferbtn_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(listBox7.Text);
            import import = context.imports.Find(ID);
            if (import != null)
            {
                int quantity = (int)import.Quantity - int.Parse(transferQuantitytxt.Text);
                if (quantity > 0)
                {
                    import.Quantity = quantity;

                    // int count = 0;
                    export export = new export();
                    export.Date = new DateTime(TransferDatePicker.Value.Ticks);
                    export.Quantity = int.Parse(transferQuantitytxt.Text);
                    // Product product = import.Product;
                    export.Product = import.Product;
                    Store store = context.Stores.Find(int.Parse(FromStoreIdcbox3.Text));
                    export.Store = import.Store;
                    Customer customer = new Customer() { name = "ahmedTurky" };
                    export.Customer = customer;
                    context.exports.Add(export);
                    context.SaveChanges();
                    RefreshExports();
                    MessageBox.Show("Transfere has been Added successfuly");
                    RefreshImports();
                }
                else
                {
                    MessageBox.Show($"Allowable Quantity is {quantity}");
                }

            }
            else
            {
                MessageBox.Show("invalid id");
            }
            RefreshExports();



        }
        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(listBox7.Text);
            import import = context.imports.Find(ID);
            if (import != null)
            {
                ProductIdcbox3.Text = import.Product_id.ToString();
                FromStoreIdcbox3.Text = import.Storage_id.ToString();
                transferQuantitytxt.Text = import.Quantity.ToString();
                TransferDatePicker.Text = import.Date.ToString();

            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }

        private void ProductIdcbox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productID = int.Parse(ProductIdcbox3.Text);
            string name = context.Products.Find(productID).name;
            textBox10.Text = name;
        }

        private void FromStoreIdcbox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int storeID = int.Parse(FromStoreIdcbox3.Text);
            string address = context.Stores.Find(storeID).address;
            textBox9.Text = address;

        }

        private void ToStoreIdcbox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int storeID = int.Parse(ToStoreIdcbox3.Text);
            string address = context.Stores.Find(storeID).address;
            textBox8.Text = address;
        }
        #endregion

        #region Functions 
        private int getProductCount(int productID, int storeID)
        {
            int count = 0;
            var queryImport = from import in context.imports
                              where import.Product_id == productID && import.Storage_id == storeID
                              select import;
            foreach (var item in queryImport)
            {
                if (item.Quantity is null)
                {
                    continue;
                }
                else
                {
                    count += (int)item.Quantity;
                }
            }

            var queryExport = from export in context.exports
                              where export.Product_id == productID && export.Storage_id == storeID
                              select export;
            foreach (var item in queryExport)
            {
                if (item.Quantity is null)
                {
                    continue;
                }
                else
                {
                    count -= (int)item.Quantity;
                }
            }
            return count;
        }










        #endregion
    }
}
