        //on save button click
        private async void BtnMPSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product();

                product.ProductID = Guid.Parse(txtMPProductID.Text);
                product.ProductName = txtMPProductName.Text;
                product.ProductCode = txtMPProductCode.Text;
                product.ProductPrice = Convert.ToDouble(txtMPProductPrice.Text);

                using (ProductBL productBL = new ProductBL())
                {
                    bool isUpdated = await productBL.UpdateProductBL(product);
                    if (isUpdated)
                    {
                        MessageBox.Show($"Product {product.ProductName} updated");
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
        private async void BtnMPDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product();

                product.ProductID = Guid.Parse(txtMPProductID.Text);

                using (ProductBL productBL = new ProductBL())
                {
                    bool isDeleted = await productBL.DeleteProductBL(product.ProductID);
                    if (isDeleted)
                    {
                        MessageBox.Show($"Product {product.ProductName} deleted");
                        loaddata();
                    }
                    else
                    {
                        MessageBox.Show("Unable to delete");
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
        private void BtnMPRefresh_Click(object sender, RoutedEventArgs e)
        {
            loaddata();
        }

        //on home button click
        private void BtnMPHome_Click(object sender, RoutedEventArgs e)
        {
            SystemUserHome systemUserHome = new SystemUserHome();
            systemUserHome.Show();
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

        //load data to datagrid from collection
        private async void loaddata()
        {
            List<Product> productsList = new List<Product>();
            try
            {
                using (ProductBL productBL = new ProductBL())
                {
                    productsList = await productBL.GetAllProductsBL();
                    if (productsList.Count > 0)
                    {
                        dgvData.ItemsSource = productsList;
                        lblStatus.Content = productsList.Count.ToString();
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
            txtMPProductID.Text = getCellData(dgvData, rowindex, 0);
            txtMPProductName.Text = getCellData(dgvData, rowindex, 1);
            txtMPProductCode.Text = getCellData(dgvData, rowindex, 2);
            txtMPProductPrice.Text = getCellData(dgvData, rowindex, 3);
            cmbProductType.Text = getCellData(dgvData, rowindex, 4);
        }

        //to get cellData of one row
        private string getCellData(DataGrid dgv, int rowindex, int cellindex)
        {
            DataGridRow drow = dgv.ItemContainerGenerator.ContainerFromIndex(rowindex) as DataGridRow;
            var cellContent = dgv.Columns[cellindex].GetCellContent(drow) as TextBlock;
            return cellContent.Text;
        }
