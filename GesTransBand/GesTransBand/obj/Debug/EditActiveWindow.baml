   M S B A M L   `   `   `  ����  GesTransBand#    GesTransBand.EditActiveWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Editar Activo��5   	   $	��320��6   $	��470��6,    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ Manual=�65   .��5      � $��10q�6   
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5	      $��50 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��170 �6   .+�5   
   �� $��0��6   $��0��6"   $��10q�62   .+�5      �� $��ID��6   �� 5      -   5        $��IdActiveTextBox��5       �� 
IsReadOnly . 
������� 	  Corto#��[  5      $
��Left=�65   �� 5      $��Línea��6   �� 5      -   5        $��DesLineTextBox��5       . 
�������#��[  5      $
��Left=�65   �� 5      $
��Zona��6   �� 5      -   5        $��DesZoneTextBox��5       . 
�������#��[  5      $
��Left=�65   �� 5      $��Descripción��6   �� 5      -   5        $��DesActiveTextBox��5       	 Largo#��[ 6.   $
��Left=�6M   6h   �� 5       $��Imagen��6   �� 5!      -   5        $��ImageActiveTextBox��5!      #��[ 60   $
��Left=�6O   5"      �� 5$   
   $��0��6   $��1��6"   $��10q�62   .+�5%      �� $��Línea��6   $
��0,10q�6%   $��Center=�63   �� 5&      -   5         ��Name$ lineaListBox��5&      $��50��6,    �� SelectedItem$ 0��68   ��5'      �� 5(      .R�5)      �� 	 �� Orientation$	 
Horizontal=�6%   .+�5*      �� ��6(   �� 
 �� Path$
 IdLine��� 5+      $��10,0,0,0q�6F   ��6(   �� $
 DesLine�6F   5,      5-      5/      �� 50      $
��Zona��6   $
��0,10q�6$   $��Center=�62   �� 51      -   5        $ zonaListBox��51      $��50��6+   $ 0��67   ��52      �� 53      .R�54      �� $	 
Horizontal=�6%   .+�55      �� ��6(   �� $
 IdZone��� 56      $��10,0,0,0q�6F   ��6(   �� $
 DesZone�6F   57      58      5:      5;      �� 5=   
   $��1��6   $��0��6"   $	 
Horizontal=�62   .+�5>      �� -   5         ��Name$ guardarButton��5>      $��Guardar��6,    
 Normal#��[ 5?      $
��Left=�65   {�.  6b   5@      �� 5A   
   $��1��6   $��1��6"   .+�5B      �� -	   5          
IconButton#��[ 5B      $��Right=�69   .��5C      �� $��imagenes/Exit_02.ico��6   5D      5E      5F      5G      