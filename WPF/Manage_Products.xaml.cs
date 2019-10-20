        //on save button click
        private void BtnMPSave_Click(object sender, RoutedEventArgs e)
        {

        }

        //on delete button click
        private void BtnMPDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        //on refresh button click
        private void BtnMPRefresh_Click(object sender, RoutedEventArgs e)
        {

        }

        //on home button click
        private void BtnMPHome_Click(object sender, RoutedEventArgs e)
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
