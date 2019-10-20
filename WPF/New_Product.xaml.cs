        //on home button click
        private void BtnNPHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
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
        private void BtnNPSave_Click(object sender, RoutedEventArgs e)
        {
            ManageProducts manageProducts = new ManageProducts();
            manageProducts.Show();
            this.Close();
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
