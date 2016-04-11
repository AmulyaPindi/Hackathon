using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            lblName.Text = Request.QueryString["Name"];

            ProfileImage.ImageUrl = Request.QueryString["PictureUrl"];
            

        }
        TreeView1.Visible = false;
        LinkButton1.Visible = false;
        Label1.Visible = false;
    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        String savepath=null;
        // Specify the path on the server to
        // save the uploaded file to.


        // Before attempting to perform operations
        // on the the file, verify that the FileUpload 
        // control contains a file.
        if (FileUpload1.HasFile)
        {
            string strText = null;
            string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            switch(ext)
            {
                case ".pdf":
                case ".doc":
                case ".docx":
                case ".txt":
                 savepath = @"C:\Users\Amulya\Desktop\Vinutha\Vinutha\Uploads\Documents\";
                    break;
                case ".png":
                case ".jpg":
                case ".jpeg":
                case ".bmp":
                case ".gif":
                    savepath = @"C:\Users\Amulya\Desktop\Vinutha\Vinutha\Uploads\Images\";
                    break;
                default:
                    savepath = @"C:\Users\Amulya\Desktop\Vinutha\Vinutha\Uploads\Others\";
                    break;
            }
         //   String savepath = @"C:\Users\Amulya\Desktop\Vinutha\Vinutha\Uploads\";
            // Append the name of the file to upload to the path.
            savepath += FileUpload1.FileName;

            // Call the SaveAs method to save the 
            // uploaded file to the specified path.
            // This example does not perform all
            // the necessary error checking.               
            // If a file with the same name
            // already exists in the specified path,  
            // the uploaded file overwrites it.
            FileUpload1.SaveAs(savepath);

            // Notify the user that the file was uploaded successfully.
            UploadStatusLabel.Text = "Your file was uploaded successfully.";

            LinkButton1.Visible = true ;
            // Call a helper routine to display the contents
            // of the file to upload.
            //  DisplayFileContents(FileUpload1.PostedFile);
        }
        else
        {
            // Notify the user that a file was not uploaded.
            UploadStatusLabel.Text = "You did not specify a file to upload.";
        }
    }
    void DisplayFileContents(HttpPostedFile file)
    {
        System.IO.Stream myStream;
        Int32 fileLen;
        StringBuilder displayString = new StringBuilder();

        // Get the length of the file.
        fileLen = FileUpload1.PostedFile.ContentLength;

        // Display the length of the file in a label.
        LengthLabel.Text = "The length of the file is " +
                           fileLen.ToString() + " bytes.";

        // Create a byte array to hold the contents of the file.
        Byte[] Input = new Byte[fileLen];

        // Initialize the stream to read the uploaded file.
        myStream = FileUpload1.FileContent;

        // Read the file into the byte array.
        myStream.Read(Input, 0, fileLen);

        // Copy the byte array to a string.
        for (int loop1 = 0; loop1 < fileLen; loop1++)
        {
            displayString.Append(Input[loop1].ToString());
        }

        // Display the contents of the file in a 
        // textbox on the page.
        ContentsLabel.Text = "The contents of the file as bytes:";

        TextBox ContentsTextBox = new TextBox();
        ContentsTextBox.TextMode = TextBoxMode.MultiLine;
        ContentsTextBox.Height = Unit.Pixel(300);
        ContentsTextBox.Width = Unit.Pixel(400);
        ContentsTextBox.Text = displayString.ToString();

        // Add the textbox to the Controls collection
        // of the Placeholder control.
        PlaceHolder1.Controls.Add(ContentsTextBox);

    }
    private void PopulateTreeView(DirectoryInfo dirInfo, TreeNode treeNode)
    {
        foreach (DirectoryInfo directory in dirInfo.GetDirectories())
        {
            TreeNode directoryNode = new TreeNode
            {
                Text = directory.Name,
                Value = directory.FullName
            };

            if (treeNode == null)
            {
                //If Root Node, add to TreeView.
                TreeView1.Nodes.Add(directoryNode);
            }
            else
            {
                //If Child Node, add to Parent Node.
                treeNode.ChildNodes.Add(directoryNode);
            }

            //Get all files in the Directory.
            foreach (FileInfo file in directory.GetFiles())
            {
                //Add each file as Child Node.
                TreeNode fileNode = new TreeNode
                {
                    Text = file.Name,
                    Value = file.FullName,
                    Target = "_blank",
                    //NavigateUrl = (new Uri(Server.MapPath("~/"))).MakeRelativeUri(new Uri(file.FullName)).ToString()
                    NavigateUrl = "View.aspx?file=" + file.Name.ToString()
                };
                directoryNode.ChildNodes.Add(fileNode);
            }

            PopulateTreeView(directory, directoryNode);
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        TreeView1.Visible = true;
        Label1.Visible = true;
        DirectoryInfo rootInfo = new DirectoryInfo(Server.MapPath("~/Uploads/"));
        PopulateTreeView(rootInfo,null);
    }
}