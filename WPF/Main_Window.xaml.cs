        
       //on New product button click
        private void BtnAddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            NewProduct newProduct = new NewProduct();
            newProduct.Show();
            this.Close();
        }

        //on Manage product button click
        private void BtnManageProducts_Click(object sender, RoutedEventArgs e)
        {
            ManageProducts manageProducts = new ManageProducts();
            manageProducts.Show();
            this.Close();
        }

        //on New Raw Materialbutton click
        private void BtnAddNewRawMaterial_Click(object sender, RoutedEventArgs e)
        {
            NewRawMaterial newRawMaterial = new NewRawMaterial();
            newRawMaterial.Show();
            this.Close();
        }

        //on manage rawmaterial click
        private void BtnManageRawMaterials_Click(object sender, RoutedEventArgs e)
        {
            ManageRawMaterials manageRawMaterials = new ManageRawMaterials();
            manageRawMaterials.Show();
            this.Close();
        }

        //on logout click
        private void BtnSystemUserLogout(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //to load data on system user home screen
        private async void loaddata()
        {
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            List<RawMaterial> rawMaterials = await rawMaterialBL.GetAllRawMaterialsBL();

            ProductBL productBL = new ProductBL();
            List<Product> products = await productBL.GetAllProductsBL();

            lblRMCount.Content = rawMaterials.Count();
            lblPCount.Content = products.Count();

        }
