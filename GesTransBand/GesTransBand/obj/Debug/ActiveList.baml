   M S B A M L   `   `   `  ����  GesTransBand    GesTransBand.ActiveList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Listado de Activos��5   	   $	��450��6$   $	��800��61    � ShowInTaskbar .   � 
ResizeMode$ 	CanResize=�5   	    � WindowStartupLocation$ CenterOwner=�5   	   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Listado de Activos��6   $��24(�6.   $
��Bold"�6<   $��Center=�6N   $��10q�6k   &   System.Windows.Controls.DataGrid  5   
   -   5        $��ActivesDataGrid��5       $��1��6      AutoGenerateColumns .     CanUserAddRows .  $��10q�6j      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *
IdActive+  5      $	 Línea��6%   
 64   �� *	DesLine+  5      $
	 Zona��6%   
 63   �� *	DesZone+  5      $	 Descripción��6%   
 6:   �� *	DesActive+  5      $	 Imagen��6%   
 65   �� *ImageActive+5      �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��10q�6W   .+�5      �� -   5         ��Name$ cleanButton��5      $��Limpiar��6*    
  Normal#��[  6<   6\   �� 5      -   5        $ 
editButton��5      $��Editar��6)   #��[  6:   {�.  6s   �� 5       -   5        $ deleteButton��5       $��Eliminar��6+   #��[  6>   {�.  6y   �� 5!      -   5          
IconButton#��[ 5!      .��5"      �� $��imagenes/Exit_02.ico��6   5#      5$      5&      5'      