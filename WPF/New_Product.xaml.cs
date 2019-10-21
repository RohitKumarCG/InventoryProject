        //on home button click
        private void BtnNPHome_Click(object sender, RoutedEventArgs e)
        {
            SystemUserHome systemUserHome = new SystemUserHome();
            systemUserHome.Show();
            this.Close();
        }

        //on reset button click
        private void BtnNPReset_Click(object sender, RoutedEventArgs e)
        {
            txtProductName.Text = string.Empty;
            txtProductCode.Text = string.Empty;
            txtPUnitPrice.Text = string.Empty;
        }

        //on save button click
        private async void BtnNPSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product();

                product.ProductName = txtProductName.Text;
                product.ProductCode = txtProductCode.Text;
                product.ProductPrice = Convert.ToDouble(txtPUnitPrice.Text);

                if (cmbProductType.Text == "Juice")
                {
                    product.ProductType = "Juice";
                }
                if (cmbProductType.Text == "Energy Drink")
                {
                    product.ProductType = "Energy Drink";
                }
                if (cmbProductType.Text == "Mocktail")
                {
                    product.ProductType = "Mocktail";
                }
                if (cmbProductType.Text == "Tonic Water")
                {
                    product.ProductType = "Tonic Water";
                }
                if (cmbProductType.Text == "Soft Drink")
                {
                    product.ProductType = "Soft Drink";
                }

                using (ProductBL productBL = new ProductBL())
                {
                    bool isAdded = await productBL.AddProductBL(product);
                    if (isAdded)
                    {
                        MessageBox.Show($"Product {product.ProductName} added");
                        ManageProducts manageProducts = new ManageProducts();
                        manageProducts.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                MessageBox.Show(ex.Message);
            }
        }

        //positive number validation
        private void positiveNumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //literal validation
        private void literalValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z ]");
            e.Handled = regex.IsMatch(e.Text);
        }
