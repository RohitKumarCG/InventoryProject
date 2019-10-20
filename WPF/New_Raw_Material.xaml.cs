        //on reset button click
        private void BtnNRMReset_Click(object sender, RoutedEventArgs e)
        {
            txtRawMaterialName.Text = string.Empty;
            txtRawMaterialCode.Text = string.Empty;
            txtRMUnitPrice.Text = string.Empty;
        }

        //on save button click
        private void BtnNRMSave_Click(object sender, RoutedEventArgs e)
        {
            ManageRawMaterials manageRawMaterials = new ManageRawMaterials();
            manageRawMaterials.Show();
            this.Close();
        }

        //on home button click
        private void BtnNRMHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
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
