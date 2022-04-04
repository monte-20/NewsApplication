<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMainWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PhotoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.CreationDateTextBox = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CreationDateLabel = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TitleTextBox = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.Preview = New System.Windows.Forms.TabPage()
        Me.BodyTextBox = New System.Windows.Forms.TextBox()
        Me.ImageTab = New System.Windows.Forms.TabPage()
        Me.ImageBox = New System.Windows.Forms.PictureBox()
        Me.CategoryPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.CategoryTextBox = New System.Windows.Forms.TextBox()
        Me.ItemList = New System.Windows.Forms.ListView()
        Me.Title = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CreationDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Description = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.Preview.SuspendLayout()
        Me.ImageTab.SuspendLayout()
        CType(Me.ImageBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CategoryPanel.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ShowToolStripMenuItem, Me.SettingToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(484, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.NewUserToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewsToolStripMenuItem, Me.PhotoToolStripMenuItem})
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'NewsToolStripMenuItem
        '
        Me.NewsToolStripMenuItem.Name = "NewsToolStripMenuItem"
        Me.NewsToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.NewsToolStripMenuItem.Text = "News..."
        '
        'PhotoToolStripMenuItem
        '
        Me.PhotoToolStripMenuItem.Name = "PhotoToolStripMenuItem"
        Me.PhotoToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.PhotoToolStripMenuItem.Text = "Photo..."
        '
        'NewUserToolStripMenuItem
        '
        Me.NewUserToolStripMenuItem.Name = "NewUserToolStripMenuItem"
        Me.NewUserToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.NewUserToolStripMenuItem.Text = "New User..."
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ShowToolStripMenuItem.Text = "Show"
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.SettingToolStripMenuItem.Text = "Setting"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ItemList, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 24)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(8)
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.14129!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.262166!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.59655!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(484, 637)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(11, 198)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.83019!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.16981!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(462, 51)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel4.Controls.Add(Me.CreationDateTextBox)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(87, 29)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(372, 19)
        Me.Panel4.TabIndex = 3
        '
        'CreationDateTextBox
        '
        Me.CreationDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CreationDateTextBox.Enabled = False
        Me.CreationDateTextBox.Location = New System.Drawing.Point(0, 0)
        Me.CreationDateTextBox.Name = "CreationDateTextBox"
        Me.CreationDateTextBox.Size = New System.Drawing.Size(372, 20)
        Me.CreationDateTextBox.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel3.Controls.Add(Me.CreationDateLabel)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 29)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(78, 19)
        Me.Panel3.TabIndex = 2
        '
        'CreationDateLabel
        '
        Me.CreationDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CreationDateLabel.AutoSize = True
        Me.CreationDateLabel.Location = New System.Drawing.Point(3, 3)
        Me.CreationDateLabel.Name = "CreationDateLabel"
        Me.CreationDateLabel.Size = New System.Drawing.Size(72, 13)
        Me.CreationDateLabel.TabIndex = 1
        Me.CreationDateLabel.Text = "Creation Date"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel2.Controls.Add(Me.TitleTextBox)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(87, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(372, 20)
        Me.Panel2.TabIndex = 1
        '
        'TitleTextBox
        '
        Me.TitleTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleTextBox.Enabled = False
        Me.TitleTextBox.Location = New System.Drawing.Point(0, 0)
        Me.TitleTextBox.Name = "TitleTextBox"
        Me.TitleTextBox.Size = New System.Drawing.Size(372, 20)
        Me.TitleTextBox.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.TitleLabel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(78, 20)
        Me.Panel1.TabIndex = 0
        '
        'TitleLabel
        '
        Me.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Location = New System.Drawing.Point(3, 3)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(27, 13)
        Me.TitleLabel.TabIndex = 0
        Me.TitleLabel.Text = "Title"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel5.Controls.Add(Me.TabControl)
        Me.Panel5.Controls.Add(Me.CategoryPanel)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(11, 255)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(462, 371)
        Me.Panel5.TabIndex = 2
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.Preview)
        Me.TabControl.Controls.Add(Me.ImageTab)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 26)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(462, 345)
        Me.TabControl.TabIndex = 1
        '
        'Preview
        '
        Me.Preview.Controls.Add(Me.BodyTextBox)
        Me.Preview.Location = New System.Drawing.Point(4, 22)
        Me.Preview.Name = "Preview"
        Me.Preview.Size = New System.Drawing.Size(454, 319)
        Me.Preview.TabIndex = 0
        Me.Preview.Text = "Preveiw"
        Me.Preview.UseVisualStyleBackColor = True
        '
        'BodyTextBox
        '
        Me.BodyTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BodyTextBox.Enabled = False
        Me.BodyTextBox.Location = New System.Drawing.Point(0, 0)
        Me.BodyTextBox.Multiline = True
        Me.BodyTextBox.Name = "BodyTextBox"
        Me.BodyTextBox.Size = New System.Drawing.Size(454, 319)
        Me.BodyTextBox.TabIndex = 0
        '
        'ImageTab
        '
        Me.ImageTab.BackColor = System.Drawing.Color.Transparent
        Me.ImageTab.Controls.Add(Me.ImageBox)
        Me.ImageTab.Location = New System.Drawing.Point(4, 22)
        Me.ImageTab.Name = "ImageTab"
        Me.ImageTab.Padding = New System.Windows.Forms.Padding(5)
        Me.ImageTab.Size = New System.Drawing.Size(454, 319)
        Me.ImageTab.TabIndex = 2
        Me.ImageTab.Text = "Image"
        '
        'ImageBox
        '
        Me.ImageBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImageBox.Location = New System.Drawing.Point(5, 5)
        Me.ImageBox.Name = "ImageBox"
        Me.ImageBox.Size = New System.Drawing.Size(444, 309)
        Me.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ImageBox.TabIndex = 1
        Me.ImageBox.TabStop = False
        '
        'CategoryPanel
        '
        Me.CategoryPanel.ColumnCount = 2
        Me.CategoryPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.CategoryPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.CategoryPanel.Controls.Add(Me.Panel6, 0, 0)
        Me.CategoryPanel.Controls.Add(Me.Panel7, 1, 0)
        Me.CategoryPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.CategoryPanel.Location = New System.Drawing.Point(0, 0)
        Me.CategoryPanel.Name = "CategoryPanel"
        Me.CategoryPanel.RowCount = 1
        Me.CategoryPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.CategoryPanel.Size = New System.Drawing.Size(462, 26)
        Me.CategoryPanel.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(78, 20)
        Me.Panel6.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Category"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.CategoryTextBox)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(87, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(372, 20)
        Me.Panel7.TabIndex = 2
        '
        'CategoryTextBox
        '
        Me.CategoryTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CategoryTextBox.Enabled = False
        Me.CategoryTextBox.Location = New System.Drawing.Point(0, 0)
        Me.CategoryTextBox.Name = "CategoryTextBox"
        Me.CategoryTextBox.Size = New System.Drawing.Size(372, 20)
        Me.CategoryTextBox.TabIndex = 0
        '
        'ItemList
        '
        Me.ItemList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Title, Me.CreationDate, Me.Description})
        Me.ItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemList.FullRowSelect = True
        Me.ItemList.HideSelection = False
        Me.ItemList.Location = New System.Drawing.Point(11, 11)
        Me.ItemList.Name = "ItemList"
        Me.ItemList.Size = New System.Drawing.Size(462, 181)
        Me.ItemList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ItemList.TabIndex = 3
        Me.ItemList.UseCompatibleStateImageBehavior = False
        Me.ItemList.View = System.Windows.Forms.View.Details
        '
        'Title
        '
        Me.Title.Text = "Title"
        Me.Title.Width = 92
        '
        'CreationDate
        '
        Me.CreationDate.Text = "Creation Date"
        Me.CreationDate.Width = 118
        '
        'Description
        '
        Me.Description.Text = "Description"
        Me.Description.Width = 237
        '
        'TextBox3
        '
        Me.TextBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(91, 3)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(384, 20)
        Me.TextBox3.TabIndex = 3
        '
        'TextBox4
        '
        Me.TextBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(91, 3)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(384, 20)
        Me.TextBox4.TabIndex = 3
        '
        'TextBox5
        '
        Me.TextBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox5.Enabled = False
        Me.TextBox5.Location = New System.Drawing.Point(88, 3)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(371, 20)
        Me.TextBox5.TabIndex = 3
        '
        'TextBox6
        '
        Me.TextBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox6.Enabled = False
        Me.TextBox6.Location = New System.Drawing.Point(88, 3)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(371, 20)
        Me.TextBox6.TabIndex = 3
        '
        'TextBox8
        '
        Me.TextBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox8.Enabled = False
        Me.TextBox8.Location = New System.Drawing.Point(88, 3)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(371, 20)
        Me.TextBox8.TabIndex = 3
        '
        'TextBox9
        '
        Me.TextBox9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox9.Enabled = False
        Me.TextBox9.Location = New System.Drawing.Point(88, 3)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(371, 20)
        Me.TextBox9.TabIndex = 3
        '
        'frmMainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(484, 661)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(500, 700)
        Me.Name = "frmMainWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FileWorx"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.TabControl.ResumeLayout(False)
        Me.Preview.ResumeLayout(False)
        Me.Preview.PerformLayout()
        Me.ImageTab.ResumeLayout(False)
        CType(Me.ImageBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CategoryPanel.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PhotoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CreationDateTextBox As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents CreationDateLabel As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TitleTextBox As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TitleLabel As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TabControl As TabControl
    Friend WithEvents Preview As TabPage
    Friend WithEvents BodyTextBox As TextBox
    Friend WithEvents CategoryPanel As TableLayoutPanel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents CategoryTextBox As TextBox
    Friend WithEvents ItemList As ListView
    Friend WithEvents Title As ColumnHeader
    Friend WithEvents CreationDate As ColumnHeader
    Friend WithEvents Description As ColumnHeader
    Friend WithEvents ImageTab As TabPage
    Friend WithEvents ImageBox As PictureBox
End Class
