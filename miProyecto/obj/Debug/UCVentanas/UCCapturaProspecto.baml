   M S B A M L   `   `   `  ����E  AmiProyecto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:miProyecto.UCVentanasmiProyecto.UCVentanas  5      = 9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=)clr-namespace:UI.UserControls;assembly=UIUI.UserControls 6@   .    (miProyecto.UCVentanas.UCCapturaProspecto   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:miProyecto.UCVentanas     5      Busercontrols)clr-namespace:UI.UserControls;assembly=UI     6@   .��5      � 
�������$��15q�6     � RowDefinitions  5	   
   �� 5
      $
��auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $��0��6   $��Captura de prospectos:��6   $��20(�6>   6N   � 5   
   $��1��6     5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60    � ColumnDefinitions 5      �� 5       $
��auto �6#   62   �� 5!      6%   .+�5$      �� $��0��6   $��0��6!   $��Datos personales��61   6N   �� 5&      $��1��6   $��0��6!   $��
Nombre(s)*��61   6H     UI.UserControls.UCTextbox  5'      -   5          Name$ 	txtNombre��5'   %   $��1��68   $��1��6E      UCIsRequired . 6k   �� 5)      $��2��6   $��0��6!   $��Apellido Paterno*��61   6O     5*      -   5        $ txtApPat��5*   %   $��2��67   $��1��6D    . 6j   �� 5,      $��3��6   $��0��6!   $��Apellido Materno��61   6N     5-      -   5        $ txtApMat��5-   %   $��3��67   $��1��6D   6V   �� 5/      $��4��6   $��0��6!   $
��RFC*��61   6B   "  UI.UserControls.UCTextboxRFC  50      -   5          Name$ txtRFC��50   (   $��4��68   $��1��6E      UCIsRequired . 6k   �� 52      $��5��6   $��0��6!   $��	Domicilio��61   6G   �� 54      $��6��6   $��0��6!   $��Calle*��61   6D     55      -   5        $ txtCalle��55   %   $��6��67   $��1��6D    . 6j   �� 57      $��7��6   $��0��6!   $��Número*��61   6E     58      -   5        $ 	txtNumero��58   %   $��7��68   $��1��6E      UCIsANumber .  . 6~   �� 5:      $��8��6   $��0��6!   $��Colonia*��61   6F     5;      -   5        $ 
txtColonia��5;   %   $��8��69   $��1��6F    . 6l   �� 5=      $��9��6   $��0��6!   $��Código Postal*��61   6L     5>      -   5        $ txtCodigoPostal��5>   %   $��9��6>   $��1��6K    .  . 6�   �� 5@      $��10��6   $��0��6"   $��
Teléfono*��62   6H     5A      -	   5        $ txtTelefono��5A   %   $��10��6:   $��1��6H    .  . 6�   �� 5C      $��11��6   $��0��6"   $��
Documentos��62   6I     UI.UserControls.UCButton  5E      -
   5          Name$ btnAgregarDocumento��5E   $   $��12��6A   $	��180��6O   $��1��6[      UCText$ Agregar Documento��6k   	   UCIcon$
	 PlusX�6�   $��Right=�6�   6�   �� 5G      -   5        
 ��Name$
 spDocumentos��5G      $��13��6/   $��1��6=   5H      5K      5L      5N      