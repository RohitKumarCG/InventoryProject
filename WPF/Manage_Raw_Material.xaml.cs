        //on home button click
        private void BtnMRMHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //on save button click
        private void BtnMRMSave_Click(object sender, RoutedEventArgs e)
        {

        }

        //on delete button click
        private void BtnMRMDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        //on refresh button click
        private void BtnMRMRefresh_Click(object sender, RoutedEventArgs e)
        {

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
