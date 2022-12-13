using Avalonia.Controls;
using Avalonia.Interactivity;
using Plugin.InAppBilling;
using System.Diagnostics;
using System;

namespace AvanoliaInAppPluginBug
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public async void OnClick(object? sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Getting product infos");

            /*            if (!CrossInAppBilling.IsSupported)
                        {
                            Debug.WriteLine("Not supported.");
                            return;
                        }*/
            var billing = CrossInAppBilling.Current;
            try
            {

                //You must connect
                var connected = await billing.ConnectAsync(false);


            }
            catch (InAppBillingPurchaseException pEx)
            {
                //Handle IAP Billing Exception
                Debug.Write(pEx.Message);
            }
            catch (Exception ex)
            {
                //Something has gone wrong
                Debug.Write(ex.Message);

            }
            finally
            {
                await billing.DisconnectAsync();
            }
        }
    }
}