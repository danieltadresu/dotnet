   M S B A M L   `   `   `  ����@  <Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ViewsViews  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5	   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
   	       Views.ModuloClientes   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Views     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	   e aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag	 cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak
 gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a^ ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   	 
                   5   	   -   5        (  "MahApps.Metro.Controls.MetroWindow   Name$  wpf_clientes��5       � Title$! ADMINISTRACIÓN DE CLIENTES��5   	   $��471.973��6,   $��726.5��6=    � Icon$< 6Resources/images/white_logo_transparent_background.png��6K    � 
ResizeMode$ CanMinimize=�6�    � WindowStartupLocation$ CenterScreen=�6�   .��5      � .+�5   
   ,  &MahApps.Metro.Controls.MetroTabControl  -   5        $��mtbMenu��5   #   .@�5      )  #MahApps.Metro.Controls.MetroTabItem     MetroTabItem#��[  6$   $��Datos Personales��6J   $��Segoe UI Light)�6d   $��153,9,-154,-13q�6�   .��5      � .+�5      �� $��RUT DEL CLIENTE��6   $
��Left=�66   $��
193,41,0,0q�6Q   $	��Top=�6e   $	��146��6}   $
��Bold"�6�   $��Segoe UI Light)�6�   $��26��6�   �� 5      $��RAZÓN SOCIAL��6   $
��Left=�63   $��
193,75,0,0q�6N   $	��Top=�6b   $	��146��6z   $
��Bold"�6�   $��Segoe UI Light)�6�   $��26��6�   �� 5      $��NOMBRE CONTACTO��6   $
��Left=�66   $��193,111,0,0q�6Q   $	��Top=�6f   $	��146��6~   $
��Bold"�6�   $��Segoe UI Light)�6�   �� 5      $��EMAIL CONTACTO��6   $
��Left=�65   $��193,141,0,0q�6P   $	��Top=�6e   $	��146��6}   $
��Bold"�6�   $��Segoe UI Light)�6�   $��28��6�   �� 5      $��
DIRECCIÓN��6   $
��Left=�60   $��193,173,0,0q�6K   $	��Top=�6`   $	��146��6x   $
��Bold"�6�   $��Segoe UI Light)�6�   �� 5      $��	TELÉFONO��6   $
��Left=�6/   $��193,203,0,0q�6J   $	��Top=�6_   $	��146��6w   $
��Bold"�6�   $��Segoe UI Light)�6�   �� 5      $��ACTIVIDA EMPRESA��6   $
��Left=�67   $��193,285,0,0q�6R   $	��Top=�6g   $	��146��6   $
��Bold"�6�   $��Segoe UI Light)�6�   �� 5       $��TIPO DE EMPRESA��6   $
��Left=�66   $��193,253,0,0q�6Q   $	��Top=�6f   $	��146��6~   $
��Bold"�6�   $��Segoe UI Light)�6�   �� 5!      -   5         ��Name$ txtRutCliente��5!       �� 	MaxLength$ 10��65   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$# Ingresa rut Formato 9999999-9��6D      ClearTextButton . $
��Left=�6�   $��26��6�   $��
345,41,0,0q�6�   	 �� TextWrapping$
	 Wrap=�6�   $�� ��6  $	��Top=�6
  $	��225��6"  �� 5"      -   5        $ txtRazonSocial��5"      $ 45��66   $ Ingresa Razón Social��6E    . $
��Left=�6�   $��23��6�   $��
345,75,0,0q�6�   $
	 Wrap=�6�   $�� ��6�   $	��Top=�6  $	��225��6  �� 5#      -   5        $ txtNombreContacto��5#      $ 45��69   $$ Ingresa rut Nombre de Contacto��6H    . $
��Left=�6�   $��23��6�   $��345,111,0,0q�6�   $
	 Wrap=�6�   $�� ��6  $	��Top=�6  $	��225��6(  �� 5$      -   5        $ txtMailContacto��5$      $ example@gmail.com��67   $ 50��6l    . $
��Left=�6�   $��23��6�   $��345,141,0,0q�6�   $
	 Wrap=�6�   $�� ��6�   $	��Top=�6  $	��225��6  �� 5%      -   5        $ txtDireccion��5%      $ Ingresa Dirección��64   $ 45��6i    . $
��Left=�6�   $��23��6�   $��345,171,0,0q�6�   $
	 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��225��6  �� 5&      -   5        $ txtnumeroContacto��5&      $ 9��6:    . $
��Left=�6v   $��23��6�   $��345,203,0,0q�6�   $" Ingresa Número de Contacto ��6�   $
	 Wrap=�6�   $�� ��6  $	��Top=�6  $	��225��6&  62  �� 5'      -	   5        
 ��Name$
 cboTipoEmpresa��5'       �� DisplayMemberPath$ Descripcion��6:    �� SelectedValuePath$ IdTipoEmpresa��6Z   $
��Left=�6|   $��345,251,0,0q�6�   $	��Top=�6�   $	��225��6�   $��26��6�    J� RenderTransformOrigin$ -0.738,1.731&�6�   �� 5(      -
   5        $
 cboActividadEmpresa��5(      $ Descripcion��6>   $ IdActividadEmpresa��6^   $
��Left=�6�   $��345,285,0,0q�6�   $	��Top=�6�   $	��225��6�   $��26��6�   �� 5)      -   5         ��Name$ btnProcesos��5)      $��ABRIR MENÚ PROCESOS��62   $
��Left=�6P   $��193,336,0,0q�6k   $	��Top=�6�   $	��139��6�   6�   �� 5*      -   5        $
 cboCargarClientes��5*      $ 
RutCliente��6:   $ 
RutCliente��6Y   $ Seleccione un Rut��6x   $��Center=�6�   $
��Left=�6�   $	��Top=�6�   $	��192��6  $��9��6  $��345,337,0,0q�6  60  5+      5,        5.      $��Nómina de Clientes��6$   $��Segoe UI Light)�6@   $��173,10,-174,-14q�6\   .��5/      � .+�50      �� $��FILTRAR��6   $
��Left=�6.   $��
197,49,0,0q�6I   $	��Top=�6]   $	��127��6u   $
��Bold"�6�   $��Trebuchet MS)�6�   �� 51      -   5        $ txtFiltrarPorRut��51      $
��Left=�68   $��23��6S   $��
324,49,0,0q�6_   $
	 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��199��6�   6�   &   System.Windows.Controls.DataGrid  52      -   5          Name$ dtgListadoClientes��52      ���#d9d4d4$��1q�6Q   $
��Left=�6e   $	��156��6�   $��
83,158,0,0q�6�   $	��Top=�6�   $	��583��6�      AutoGenerateColumns .  $��Trebuchet MS)�6�   {�.    Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ RUT CLIENTE��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6w   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6X   �� *
RutCliente+6w     55       . $ RAZÓN SOCIAL��6C   $	 150 6y    6Y   �� *RazonSocial+6y     56       . $ NOMBRE CLIENTE��6C   $	 150 6~    6[   �� *NombreContacto+6~     57       . $ CANTIDAD CONTRATOS��6C   $	 150 6�    6_   ��  �� Path$ Contrato.Count�6�   59      �� 5:      $��
BUSCAR POR��6   $��Center=�61   ���#2D3748
�������$
��Left=�6}   $��
186,78,0,0q�6�   $	��Top=�6�   $��Trebuchet MS)�6�   $
��Bold"�6�   $	��337��6�   	� 5;      -   5         	�Name$ rbtnRutCliente��5;   "   $	��Rut��6:   $
��Left=�6H   $��197,111,0,0q�6c   $��Trebuchet MS)�6x   $	��Top=�6�   $
��Bold"�6�   $��72��6�   6�   	� 5<      -   5        $ rbtnNombreCliente��5<   "   $��Nombre o Apellido��6=   $
��Left=�6Y   $��274,111,0,0q�6t   $��Trebuchet MS)�6�   $	��Top=�6�   $
��Bold"�6�   6�   5=      5>      5B      #
  MahApps.Metro.Controls.Flyout
  5D   
   -   5         
 Name$ 
flProcesos��5D      $	��222��6.    
  Position$ Right=�6:   
�������$��Procesos��6^   ��5E      �� 5F       �� Color$ 	#FF252424��6"    �� Opacity$	 0.9Q�64   .��5H      �� .+�5I      �� -   5        $ btnCreateCliente��5I      $��	REGISTRAR��63   $
��Left=�6G   $	��Top=�6b   $��92��6z   $��22��6�    �� Left$ 72��6�   
 �� Top$ 67��6�   �� 5J      -   5        $ btnReadCliente��5J      $��BUSCAR��61   $
��Left=�6B   $	��Top=�6]   $��92��6u   $��22��6�   $ 72��6�   $ 98��6�   �� 5K      -   5        $ btnUpdateCliente��5K      $��	MODIFICAR��63   $
��Left=�6G   $	��Top=�6b   $��92��6z   $��22��6�   $ 72��6�   $	 128��6�   �� 5L      -   5        $ btnDeleteCliente��5L      $��ELIMINAR��63   $
��Left=�6F   $	��Top=�6a   $��92��6y   $��22��6�   $ 72��6�   $	 158��6�   �� 5M      -   5        $ 
btnRefresh��5M      $��REFRESH��6-   $
��Left=�6@   $	��Top=�6[   $��92��6s   $��22��6~   $ 72��6�   $	 188��6�   �� 5N      -   5        $ abrirListadoClientes��5N      $��VER LISTA DE CLIENTES��68   $
��Left=�6Y   $	��Top=�6t   $	��150��6�   $	 218��6�   $ 44��6�   5P      5Q      5R      5S      