   M S B A M L   `   `   `  ����E  AmiProyecto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:miProyecto
miProyecto  5   	   = 9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=)clr-namespace:UI.UserControls;assembly=UIUI.UserControls 60       miProyecto.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:miProyecto     5   	   Busercontrols)clr-namespace:UI.UserControls;assembly=UI     60     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Login��5	   	   $��226.073��6   $��380.876��6(   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $��* �6   �� 5      $
��0.2* �6    � RowDefinitions 5   
   �� 5      $
��0.2* �6   6,   �� 5      $��* �6   6)   �� 5      $
��0.2* �6   6,   .+�5   
   � $��1��6   $��1��6    5      �� 5      $
��0.5* �6#   62   �� 5      6%    5      �� 5      6#   �� 5      6#   �� 5      6#   .+�5      �� $��0��6   $��0��6$   $��Usuario:��61   $
��Left=�6D   $��5q�6_   �� 5       $��0��6   $��1��6$   $��Contraseña:��61   $
��Left=�6G   $��5q�6b     UI.UserControls.UCTextbox  5!      -   5          Name$ txtUser��5!   %   $��1��66   $��0��6F   $��5q�6S      UCText$  ��6^   6j      UI.UserControls.UCPassword  5"      -   5          Name$ txtPassword��5"   &   $��1��6;   $��1��6K   $��5q�6X      UCPasswordText$  ��6c   6w     UI.UserControls.UCButton  5#      -   5          Name$ 	btnEntrar��5#   S   $��1��6$   $��2��64   $��20,5,5,5q�6A   	   UCText$	 Entrar��6f   
   UCIcon$	
 KeyX�6v   $	��100��6�   $��Right=�6�      UCIsEnabled . 6�   5$      5'      5(      