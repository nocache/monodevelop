// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoDevelop.Gettext.Editor {
    
    
    internal partial class CatalogHeadersWidget {
        
        private Gtk.Notebook notebook1;
        
        private Gtk.Table table1;
        
        private Gtk.Entry entryBugzilla;
        
        private Gtk.Entry entryProjectName;
        
        private Gtk.Entry entryProjectVersion;
        
        private Gtk.Label label4;
        
        private Gtk.Label label5;
        
        private Gtk.Label label6;
        
        private Gtk.Label label7;
        
        private Gtk.Label label8;
        
        private Gtk.Label label9;
        
        private Gtk.Label labelPoLastModification;
        
        private Gtk.Label labelPotCreation;
        
        private Gtk.ScrolledWindow scrolledwindow1;
        
        private Gtk.TextView textviewComments;
        
        private Gtk.Label label3;
        
        private Gtk.Table table2;
        
        private Gtk.ComboBoxEntry comboboxentryCharset;
        
        private Gtk.Entry entryLanguageGroupEmail;
        
        private Gtk.Entry entryLanguageGroupName;
        
        private Gtk.Entry entryTranslatorEmail;
        
        private Gtk.Entry entryTranslatorName;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Entry entryPluralsForms;
        
        private Gtk.Label label10;
        
        private Gtk.Label label11;
        
        private Gtk.Label label12;
        
        private Gtk.Label label13;
        
        private Gtk.Label label14;
        
        private Gtk.Label label15;
        
        private Gtk.Label label2;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize();
            // Widget MonoDevelop.Gettext.Editor.CatalogHeadersWidget
            Stetic.BinContainer.Attach(this);
            this.Name = "MonoDevelop.Gettext.Editor.CatalogHeadersWidget";
            // Container child MonoDevelop.Gettext.Editor.CatalogHeadersWidget.Gtk.Container+ContainerChild
            this.notebook1 = new Gtk.Notebook();
            this.notebook1.CanFocus = true;
            this.notebook1.Name = "notebook1";
            this.notebook1.CurrentPage = 0;
            this.notebook1.TabPos = ((Gtk.PositionType)(0));
            this.notebook1.BorderWidth = ((uint)(8));
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.table1 = new Gtk.Table(((uint)(6)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            this.table1.BorderWidth = ((uint)(8));
            // Container child table1.Gtk.Table+TableChild
            this.entryBugzilla = new Gtk.Entry();
            this.entryBugzilla.CanFocus = true;
            this.entryBugzilla.Name = "entryBugzilla";
            this.entryBugzilla.IsEditable = true;
            this.entryBugzilla.InvisibleChar = '●';
            this.table1.Add(this.entryBugzilla);
            Gtk.Table.TableChild w1 = ((Gtk.Table.TableChild)(this.table1[this.entryBugzilla]));
            w1.TopAttach = ((uint)(3));
            w1.BottomAttach = ((uint)(4));
            w1.LeftAttach = ((uint)(1));
            w1.RightAttach = ((uint)(2));
            w1.XOptions = ((Gtk.AttachOptions)(4));
            w1.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.entryProjectName = new Gtk.Entry();
            this.entryProjectName.CanFocus = true;
            this.entryProjectName.Name = "entryProjectName";
            this.entryProjectName.IsEditable = true;
            this.entryProjectName.InvisibleChar = '●';
            this.table1.Add(this.entryProjectName);
            Gtk.Table.TableChild w2 = ((Gtk.Table.TableChild)(this.table1[this.entryProjectName]));
            w2.TopAttach = ((uint)(1));
            w2.BottomAttach = ((uint)(2));
            w2.LeftAttach = ((uint)(1));
            w2.RightAttach = ((uint)(2));
            w2.XOptions = ((Gtk.AttachOptions)(4));
            w2.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.entryProjectVersion = new Gtk.Entry();
            this.entryProjectVersion.CanFocus = true;
            this.entryProjectVersion.Name = "entryProjectVersion";
            this.entryProjectVersion.IsEditable = true;
            this.entryProjectVersion.InvisibleChar = '●';
            this.table1.Add(this.entryProjectVersion);
            Gtk.Table.TableChild w3 = ((Gtk.Table.TableChild)(this.table1[this.entryProjectVersion]));
            w3.TopAttach = ((uint)(2));
            w3.BottomAttach = ((uint)(3));
            w3.LeftAttach = ((uint)(1));
            w3.RightAttach = ((uint)(2));
            w3.XOptions = ((Gtk.AttachOptions)(4));
            w3.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.Xalign = 0F;
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("Last modification:");
            this.table1.Add(this.label4);
            Gtk.Table.TableChild w4 = ((Gtk.Table.TableChild)(this.table1[this.label4]));
            w4.TopAttach = ((uint)(5));
            w4.BottomAttach = ((uint)(6));
            w4.XOptions = ((Gtk.AttachOptions)(4));
            w4.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.Xalign = 0F;
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("Comments:");
            this.table1.Add(this.label5);
            Gtk.Table.TableChild w5 = ((Gtk.Table.TableChild)(this.table1[this.label5]));
            w5.XOptions = ((Gtk.AttachOptions)(4));
            w5.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label6 = new Gtk.Label();
            this.label6.Name = "label6";
            this.label6.Xalign = 0F;
            this.label6.LabelProp = Mono.Unix.Catalog.GetString("Project name:");
            this.table1.Add(this.label6);
            Gtk.Table.TableChild w6 = ((Gtk.Table.TableChild)(this.table1[this.label6]));
            w6.TopAttach = ((uint)(1));
            w6.BottomAttach = ((uint)(2));
            w6.XOptions = ((Gtk.AttachOptions)(4));
            w6.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label7 = new Gtk.Label();
            this.label7.Name = "label7";
            this.label7.Xalign = 0F;
            this.label7.LabelProp = Mono.Unix.Catalog.GetString("Project version:");
            this.table1.Add(this.label7);
            Gtk.Table.TableChild w7 = ((Gtk.Table.TableChild)(this.table1[this.label7]));
            w7.TopAttach = ((uint)(2));
            w7.BottomAttach = ((uint)(3));
            w7.XOptions = ((Gtk.AttachOptions)(4));
            w7.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label8 = new Gtk.Label();
            this.label8.Name = "label8";
            this.label8.Xalign = 0F;
            this.label8.LabelProp = Mono.Unix.Catalog.GetString("Bugzilla URL:");
            this.table1.Add(this.label8);
            Gtk.Table.TableChild w8 = ((Gtk.Table.TableChild)(this.table1[this.label8]));
            w8.TopAttach = ((uint)(3));
            w8.BottomAttach = ((uint)(4));
            w8.XOptions = ((Gtk.AttachOptions)(4));
            w8.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label9 = new Gtk.Label();
            this.label9.Name = "label9";
            this.label9.Xalign = 0F;
            this.label9.LabelProp = Mono.Unix.Catalog.GetString("Creation date:");
            this.table1.Add(this.label9);
            Gtk.Table.TableChild w9 = ((Gtk.Table.TableChild)(this.table1[this.label9]));
            w9.TopAttach = ((uint)(4));
            w9.BottomAttach = ((uint)(5));
            w9.XOptions = ((Gtk.AttachOptions)(4));
            w9.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.labelPoLastModification = new Gtk.Label();
            this.labelPoLastModification.Name = "labelPoLastModification";
            this.labelPoLastModification.Xalign = 0F;
            this.labelPoLastModification.LabelProp = "";
            this.labelPoLastModification.UseMarkup = true;
            this.table1.Add(this.labelPoLastModification);
            Gtk.Table.TableChild w10 = ((Gtk.Table.TableChild)(this.table1[this.labelPoLastModification]));
            w10.TopAttach = ((uint)(5));
            w10.BottomAttach = ((uint)(6));
            w10.LeftAttach = ((uint)(1));
            w10.RightAttach = ((uint)(2));
            w10.XOptions = ((Gtk.AttachOptions)(4));
            w10.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.labelPotCreation = new Gtk.Label();
            this.labelPotCreation.Name = "labelPotCreation";
            this.labelPotCreation.Xalign = 0F;
            this.labelPotCreation.LabelProp = "";
            this.labelPotCreation.UseMarkup = true;
            this.table1.Add(this.labelPotCreation);
            Gtk.Table.TableChild w11 = ((Gtk.Table.TableChild)(this.table1[this.labelPotCreation]));
            w11.TopAttach = ((uint)(4));
            w11.BottomAttach = ((uint)(5));
            w11.LeftAttach = ((uint)(1));
            w11.RightAttach = ((uint)(2));
            w11.XOptions = ((Gtk.AttachOptions)(4));
            w11.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.scrolledwindow1 = new Gtk.ScrolledWindow();
            this.scrolledwindow1.CanFocus = true;
            this.scrolledwindow1.Name = "scrolledwindow1";
            this.scrolledwindow1.VscrollbarPolicy = ((Gtk.PolicyType)(1));
            this.scrolledwindow1.HscrollbarPolicy = ((Gtk.PolicyType)(1));
            this.scrolledwindow1.ShadowType = ((Gtk.ShadowType)(1));
            // Container child scrolledwindow1.Gtk.Container+ContainerChild
            this.textviewComments = new Gtk.TextView();
            this.textviewComments.HeightRequest = 180;
            this.textviewComments.CanFocus = true;
            this.textviewComments.Name = "textviewComments";
            this.scrolledwindow1.Add(this.textviewComments);
            this.table1.Add(this.scrolledwindow1);
            Gtk.Table.TableChild w13 = ((Gtk.Table.TableChild)(this.table1[this.scrolledwindow1]));
            w13.LeftAttach = ((uint)(1));
            w13.RightAttach = ((uint)(2));
            w13.YOptions = ((Gtk.AttachOptions)(4));
            this.notebook1.Add(this.table1);
            Gtk.Notebook.NotebookChild w14 = ((Gtk.Notebook.NotebookChild)(this.notebook1[this.table1]));
            w14.TabExpand = false;
            // Notebook tab
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("Project settings");
            this.notebook1.SetTabLabel(this.table1, this.label3);
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.table2 = new Gtk.Table(((uint)(6)), ((uint)(2)), false);
            this.table2.Name = "table2";
            this.table2.RowSpacing = ((uint)(6));
            this.table2.ColumnSpacing = ((uint)(6));
            this.table2.BorderWidth = ((uint)(8));
            // Container child table2.Gtk.Table+TableChild
            this.comboboxentryCharset = new Gtk.ComboBoxEntry();
            this.comboboxentryCharset.Name = "comboboxentryCharset";
            this.table2.Add(this.comboboxentryCharset);
            Gtk.Table.TableChild w15 = ((Gtk.Table.TableChild)(this.table2[this.comboboxentryCharset]));
            w15.TopAttach = ((uint)(4));
            w15.BottomAttach = ((uint)(5));
            w15.LeftAttach = ((uint)(1));
            w15.RightAttach = ((uint)(2));
            w15.XOptions = ((Gtk.AttachOptions)(4));
            w15.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.entryLanguageGroupEmail = new Gtk.Entry();
            this.entryLanguageGroupEmail.CanFocus = true;
            this.entryLanguageGroupEmail.Name = "entryLanguageGroupEmail";
            this.entryLanguageGroupEmail.IsEditable = true;
            this.entryLanguageGroupEmail.InvisibleChar = '●';
            this.table2.Add(this.entryLanguageGroupEmail);
            Gtk.Table.TableChild w16 = ((Gtk.Table.TableChild)(this.table2[this.entryLanguageGroupEmail]));
            w16.TopAttach = ((uint)(3));
            w16.BottomAttach = ((uint)(4));
            w16.LeftAttach = ((uint)(1));
            w16.RightAttach = ((uint)(2));
            w16.XOptions = ((Gtk.AttachOptions)(4));
            w16.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.entryLanguageGroupName = new Gtk.Entry();
            this.entryLanguageGroupName.CanFocus = true;
            this.entryLanguageGroupName.Name = "entryLanguageGroupName";
            this.entryLanguageGroupName.IsEditable = true;
            this.entryLanguageGroupName.InvisibleChar = '●';
            this.table2.Add(this.entryLanguageGroupName);
            Gtk.Table.TableChild w17 = ((Gtk.Table.TableChild)(this.table2[this.entryLanguageGroupName]));
            w17.TopAttach = ((uint)(2));
            w17.BottomAttach = ((uint)(3));
            w17.LeftAttach = ((uint)(1));
            w17.RightAttach = ((uint)(2));
            w17.XOptions = ((Gtk.AttachOptions)(4));
            w17.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.entryTranslatorEmail = new Gtk.Entry();
            this.entryTranslatorEmail.CanFocus = true;
            this.entryTranslatorEmail.Name = "entryTranslatorEmail";
            this.entryTranslatorEmail.IsEditable = true;
            this.entryTranslatorEmail.InvisibleChar = '●';
            this.table2.Add(this.entryTranslatorEmail);
            Gtk.Table.TableChild w18 = ((Gtk.Table.TableChild)(this.table2[this.entryTranslatorEmail]));
            w18.TopAttach = ((uint)(1));
            w18.BottomAttach = ((uint)(2));
            w18.LeftAttach = ((uint)(1));
            w18.RightAttach = ((uint)(2));
            w18.XOptions = ((Gtk.AttachOptions)(4));
            w18.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.entryTranslatorName = new Gtk.Entry();
            this.entryTranslatorName.CanFocus = true;
            this.entryTranslatorName.Name = "entryTranslatorName";
            this.entryTranslatorName.IsEditable = true;
            this.entryTranslatorName.InvisibleChar = '●';
            this.table2.Add(this.entryTranslatorName);
            Gtk.Table.TableChild w19 = ((Gtk.Table.TableChild)(this.table2[this.entryTranslatorName]));
            w19.LeftAttach = ((uint)(1));
            w19.RightAttach = ((uint)(2));
            w19.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 4;
            // Container child hbox2.Gtk.Box+BoxChild
            this.entryPluralsForms = new Gtk.Entry();
            this.entryPluralsForms.CanFocus = true;
            this.entryPluralsForms.Name = "entryPluralsForms";
            this.entryPluralsForms.IsEditable = true;
            this.entryPluralsForms.InvisibleChar = '●';
            this.hbox2.Add(this.entryPluralsForms);
            Gtk.Box.BoxChild w20 = ((Gtk.Box.BoxChild)(this.hbox2[this.entryPluralsForms]));
            w20.Position = 0;
            this.table2.Add(this.hbox2);
            Gtk.Table.TableChild w21 = ((Gtk.Table.TableChild)(this.table2[this.hbox2]));
            w21.TopAttach = ((uint)(5));
            w21.BottomAttach = ((uint)(6));
            w21.LeftAttach = ((uint)(1));
            w21.RightAttach = ((uint)(2));
            w21.XOptions = ((Gtk.AttachOptions)(4));
            w21.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.label10 = new Gtk.Label();
            this.label10.Name = "label10";
            this.label10.Xalign = 0F;
            this.label10.LabelProp = Mono.Unix.Catalog.GetString("Translator name:");
            this.table2.Add(this.label10);
            Gtk.Table.TableChild w22 = ((Gtk.Table.TableChild)(this.table2[this.label10]));
            w22.XOptions = ((Gtk.AttachOptions)(4));
            w22.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.label11 = new Gtk.Label();
            this.label11.Name = "label11";
            this.label11.Xalign = 0F;
            this.label11.LabelProp = Mono.Unix.Catalog.GetString("Translator e-mail::");
            this.table2.Add(this.label11);
            Gtk.Table.TableChild w23 = ((Gtk.Table.TableChild)(this.table2[this.label11]));
            w23.TopAttach = ((uint)(1));
            w23.BottomAttach = ((uint)(2));
            w23.XOptions = ((Gtk.AttachOptions)(4));
            w23.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.label12 = new Gtk.Label();
            this.label12.Name = "label12";
            this.label12.Xalign = 0F;
            this.label12.LabelProp = Mono.Unix.Catalog.GetString("Language group:");
            this.table2.Add(this.label12);
            Gtk.Table.TableChild w24 = ((Gtk.Table.TableChild)(this.table2[this.label12]));
            w24.TopAttach = ((uint)(2));
            w24.BottomAttach = ((uint)(3));
            w24.XOptions = ((Gtk.AttachOptions)(4));
            w24.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.label13 = new Gtk.Label();
            this.label13.Name = "label13";
            this.label13.Xalign = 0F;
            this.label13.LabelProp = Mono.Unix.Catalog.GetString("Language group e-mail:");
            this.table2.Add(this.label13);
            Gtk.Table.TableChild w25 = ((Gtk.Table.TableChild)(this.table2[this.label13]));
            w25.TopAttach = ((uint)(3));
            w25.BottomAttach = ((uint)(4));
            w25.XOptions = ((Gtk.AttachOptions)(4));
            w25.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.label14 = new Gtk.Label();
            this.label14.Name = "label14";
            this.label14.Xalign = 0F;
            this.label14.LabelProp = Mono.Unix.Catalog.GetString("Charset:");
            this.table2.Add(this.label14);
            Gtk.Table.TableChild w26 = ((Gtk.Table.TableChild)(this.table2[this.label14]));
            w26.TopAttach = ((uint)(4));
            w26.BottomAttach = ((uint)(5));
            w26.XOptions = ((Gtk.AttachOptions)(4));
            w26.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.label15 = new Gtk.Label();
            this.label15.Name = "label15";
            this.label15.Xalign = 0F;
            this.label15.LabelProp = Mono.Unix.Catalog.GetString("Plural forms:");
            this.table2.Add(this.label15);
            Gtk.Table.TableChild w27 = ((Gtk.Table.TableChild)(this.table2[this.label15]));
            w27.TopAttach = ((uint)(5));
            w27.BottomAttach = ((uint)(6));
            w27.XOptions = ((Gtk.AttachOptions)(4));
            w27.YOptions = ((Gtk.AttachOptions)(4));
            this.notebook1.Add(this.table2);
            Gtk.Notebook.NotebookChild w28 = ((Gtk.Notebook.NotebookChild)(this.notebook1[this.table2]));
            w28.Position = 1;
            w28.TabExpand = false;
            // Notebook tab
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Language settings");
            this.notebook1.SetTabLabel(this.table2, this.label2);
            this.Add(this.notebook1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.entryProjectVersion.Changed += new System.EventHandler(this.OnHeaderChanged);
            this.entryProjectName.Changed += new System.EventHandler(this.OnHeaderChanged);
            this.entryBugzilla.Changed += new System.EventHandler(this.OnHeaderChanged);
            this.entryPluralsForms.Changed += new System.EventHandler(this.OnHeaderChanged);
            this.entryTranslatorName.Changed += new System.EventHandler(this.OnHeaderChanged);
            this.entryTranslatorEmail.Changed += new System.EventHandler(this.OnHeaderChanged);
            this.entryLanguageGroupName.Changed += new System.EventHandler(this.OnHeaderChanged);
            this.entryLanguageGroupEmail.Changed += new System.EventHandler(this.OnHeaderChanged);
        }
    }
}
