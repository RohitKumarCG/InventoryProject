        
        private void BtnAddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            NewProduct newProduct = new NewProduct();
            newProduct.Show();
            this.Close();
        }

        private void BtnManageProducts_Click(object sender, RoutedEventArgs e)
        {
            ManageProducts manageProducts = new ManageProducts();
            manageProducts.Show();
            this.Close();
        }

        private void BtnAddNewRawMaterial_Click(object sender, RoutedEventArgs e)
        {
            NewRawMaterial newRawMaterial = new NewRawMaterial();
            newRawMaterial.Show();
            this.Close();
        }
        
        private void BtnManageRawMaterials_Click(object sender, RoutedEventArgs e)
        {
            ManageRawMaterials manageRawMaterials = new ManageRawMaterials();
            manageRawMaterials.Show();
            this.Close();
        }
