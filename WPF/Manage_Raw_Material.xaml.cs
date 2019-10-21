        //on home button click
        private void BtnMRMHome_Click(object sender, RoutedEventArgs e)
        {
            SystemUserHome systemUserHome = new SystemUserHome();
            systemUserHome.Show();
            this.Close();
        }

        //on save button click
        private async void BtnMRMSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RawMaterial rawMaterial = new RawMaterial();

                rawMaterial.RawMaterialID = Guid.Parse(txtMRMRawMaterialID.Text);
                rawMaterial.RawMaterialName = txtMRMRawMaterialName.Text;
                rawMaterial.RawMaterialCode = txtMRMRawMaterialCode.Text;
                rawMaterial.RawMaterialPrice = Convert.ToDouble(txtMRMRawMaterialUnitPrice.Text);

                using (RawMaterialBL rawMaterialBL = new RawMaterialBL())
                {
                    bool isUpdated = await rawMaterialBL.UpdateRawMaterialBL(rawMaterial);
                    if (isUpdated)
                    {
                        MessageBox.Show($"Raw Material {rawMaterial.RawMaterialName} updated");
                        loaddata();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                MessageBox.Show(ex.Message);
            }
        }

        //on delete button click
        private async void BtnMRMDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RawMaterial rawMaterial = new RawMaterial();

                rawMaterial.RawMaterialID = Guid.Parse(txtMRMRawMaterialID.Text);
                
                using (RawMaterialBL rawMaterialBL = new RawMaterialBL())
                {
                    bool isDeleted = await rawMaterialBL.DeleteRawMaterialBL(rawMaterial.RawMaterialID);
                    if (isDeleted)
                    {
                        MessageBox.Show($"Raw Material {rawMaterial.RawMaterialName} deleted");
                        loaddata();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                MessageBox.Show(ex.Message);
            }
        }

        //on refresh button click
        private void BtnMRMRefresh_Click(object sender, RoutedEventArgs e)
        {
            loaddata();
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

        //load data to datagrid from collection
        private async void loaddata()
        {
            List<RawMaterial> rawMaterialsList = new List<RawMaterial>();
            try
            {
                using (RawMaterialBL rawMaterialBL = new RawMaterialBL())
                {
                    rawMaterialsList = await rawMaterialBL.GetAllRawMaterialsBL();
                    if (rawMaterialsList.Count > 0)
                    {
                        dgvData.ItemsSource = rawMaterialsList;
                        lblStatus.Content = rawMaterialsList.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                MessageBox.Show(ex.Message);
            }
        }

        //get values in textbox when datagrid selection changes
        private void dgvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int rowindex = dgvData.SelectedIndex;
            if (rowindex < 0)
            {
                return;
            }
            txtMRMRawMaterialID.Text = getCellData(dgvData, rowindex, 0);
            txtMRMRawMaterialName.Text = getCellData(dgvData, rowindex, 1);
            txtMRMRawMaterialCode.Text = getCellData(dgvData, rowindex, 2);
            txtMRMRawMaterialUnitPrice.Text = getCellData(dgvData, rowindex, 3);
        }

        //to get cellData of one row
        private string getCellData(DataGrid dgv, int rowindex, int cellindex)
        {
            DataGridRow drow = dgv.ItemContainerGenerator.ContainerFromIndex(rowindex) as DataGridRow;
            var cellContent = dgv.Columns[cellindex].GetCellContent(drow) as TextBlock;
            return cellContent.Text;
        }
