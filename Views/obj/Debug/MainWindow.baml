   M S B A M L   `   `   `  ����@  <Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ViewsViews  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5	   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
   	       Views.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Views     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	   e aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag	 cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak
 gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a^ ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   	 
                   5   	   -   5        (  "MahApps.Metro.Controls.MetroWindow   Name$  wpf_menu��5       � Title$ INICIO��5   	   $	��600��6   $	��800��6&    � WindowStartupLocation$ CenterScreen=�63    � 
ResizeMode$ CanMinimize=�6X    � Icon$< 6Resources/images/white_logo_transparent_background.png��6q   .��5      � .+�5   
   �� $��OnBreak Eventos��6   $
��25px(�6*   $
��Bold"�6:   $
��Left=�6L   $
��Left=�6n   $��	38,22,0,0q�6�   $	��Top=�6�   $��72��6�   $	��201��6�   $��Segoe UI Light)�6�   �� 5   
   $��Empresariales��6   $
��25px(�6(   $
��Bold"�68   $
��Left=�6J   $
��Left=�6l   $��	38,62,0,0q�6�   $	��Top=�6�   $��45��6�   $	��201��6�   $��Segoe UI Light)�6�   �� 5   
   $��	Acerca De��6   $��SemiBold"�6%   $��Segoe UI Light)�6;   $
��Left=�6W   $
��Left=�6y   $��
360,94,0,0q�6�   $	��Top=�6�   $��25��6�   $��73��6�   �� 5   
   $��
Modo Claro��6   $��SemiBold"�6&   $��Segoe UI Light)�6<   $
��Left=�6X   $
��Left=�6z   $��
476,94,0,0q�6�   $	��Top=�6�   $��25��6�   $��76��6�   �� 5   
   $��Modo Oscuro��6   $��SemiBold"�6&   $��Segoe UI Light)�6<   $
��Left=�6X   $
��Left=�6z   $��
597,94,0,0q�6�   $	��Top=�6�   $��25��6�   $��93��6�   !  MahApps.Metro.Controls.Tile  5   
   -   5          Name$ AcercaDe��5         Title$ 	Acerca De��6*      AccentedSquareButtonStyle#��[  6<   $��360,22,332,475q�5      $
��Auto��5      $
��Auto��5      ���#4A5568.��5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Tools=�6)   $��25��5      $��25��5      $��Center=�5       $��Center=�5!      5#        5$   
   -   5        $ tlModoLight��5$      $ 
Tema Light��6-   #��[  6@   $��476,22,216,475q�5%      $
��Auto��5&      $
��Auto��5'      ���#4A5568.��5*        $ 
Sunglasses=�6)   $��25��5+   -   $��25��5,   -   $��Center=�5-   -   $��Center=�5.   -   5/      51        53   
   -   5        $ tlModoLightDark��53      $ Tema Light Dark��61   #��[  6I   $��597,22,89,475q�54      $
��Auto��55      $
��Auto��56      ���#4A5568.��59        $ ThemeLightDark=�6)   $��25��5:      $��25��5;      $��Center=�5<      $��Center=�5=      5>      � 5A   
   -   5         �Name$ wpMenu��5A      $��27,151,33,-91q�6$   .+�5B        -   5        $ tlAdministradorCliente��5B      $! Administración de Clientes��6<   $��Segoe UI Light)�6_   $��5,5,5,5q�5C      $	��170��5D      $	��500��5E      ���#2D3748.��5H        $ Human=�6-   $	��100��5I   -   $	��100��5J   -   $��Center=�5K   -   $��Center=�5L   -   5M      5O        5Q      -   5        $ tlListadoAutores��5Q      $ Listado de Clientes��66   $��Segoe UI Light)�6R   $��5,5,5,5q�5R      $	��170��5S      $	��200��5T      ���#4A5568.��5V        $ FileAccountOutline=�6-   $	��100��5W   -   $	��100��5X   -   $��Center=�5Y   -   $��Center=�5Z   -   5[      5]        5_      -   5        $ tlAdministracionContratos��5_      $" Administración de Contratos��6?   $��Segoe UI Light)�6c   $��5,5,5,5q�5`      $	��170��5a      $	��500��5b      ���#2D3748.��5d        $ FileDocument=�6-   $	��100��5e   -   $	��100��5f   -   $��Center=�5g   -   $��Center=�5h   -   5i      5j        5l      -	   5        $ tlListadoContratos��5l      $ Listado de Contratos��68   $��Segoe UI Light)�6U   $��5,5,5,5q�5m      $	��170��5n      $	��200��5o      ���#4A5568.��5q        $ ClipboardFile=�6-   $	��100��5r   -   $	��100��5s   -   $��Center=�5t   -   $��Center=�5u   -   5v      5w      5x      #  MahApps.Metro.Controls.Flyout  5z   
   -
   5        	  Name$	 
flAcercaDe��5z      $	��318��6.   
   Position$
 Right=�6:   
�������$��	Acerca De��6^   ��5{      �� 5|       �� Color$ 	#FF252424��6"    �� Opacity$	 0.9Q�64   .��5~      �� .+�5      �� 
�������$��16(�6+   $��Center=�69   $!��Proyecto Desarrollador Para��6]   $	��291��6�   
 �� Top$ 36��6�   �� 5�      
�������$��16(�6+   $��Center=�69   $��DSY009D��6]   $	��291��6o   $ 67��6{   �� 5�      
�������$��16(�6+   $��Center=�69   $��PROFESOR��6]   $	��291��6p   $	 140��6|   �� 5�      
�������$��16(�6+   $��Center=�69   $"��CHRISTIAN SARMIENTO ZAMPILLO��6]   $	��291��6�   $	 176��6�   5�      5�      5�      5�      