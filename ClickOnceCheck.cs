private void ClickOnceCheck()
        {
            try
            { 
               
                if (!(ApplicationDeployment.IsNetworkDeployed))
                {
                    return;
                } 
              
                System.Deployment.Application.ApplicationDeployment obj = ApplicationDeployment.CurrentDeployment;
                if (ApplicationDeployment.CurrentDeployment.CheckForUpdate())
                {
                    obj.UpdateCompleted += new AsyncCompletedEventHandler(obj_UpdateCompleted);
                    obj.UpdateAsync();
                }
                else
                {
                    MessageBox.Show("no");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void obj_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Application.Restart();
        }
		
		
		 http://domain/TestClickOnce/TestClickOnce.application?A=1&B=2&C=3
        private NameValueCollection GetClickOnceParameters()
        {
            string QueryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
            NameValueCollection Gets = new NameValueCollection();
            Gets = System.Web.HttpUtility.ParseQueryString(QueryString);

            List<Gets> ListGets = new List<Gets>();

            foreach (String s in Gets.AllKeys)
            {
                Gets item = new Gets();
                item.QueryStringKey = s;
                item.QueryStringValue = Gets[s];
                ListGets.Add(item);
            }

            return  ListGets;
        }

        public class Gets
        {
            public string QueryStringKey { get; set; }
            public string QueryStringValue { get; set; }
        }