   M S B A M L   `   `   `  ����>  :ATM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ATMATM  5   	       	ATM.login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:ATM     5   	     � Title$  login��5   	   $	��450��6   $	��800��6$    � WindowStartupLocation$ CenterScreen=�60    � 
ResizeMode$ NoResize=�6U   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��307 �6   �� 5      $	��211 �6   �� 5      $	��274 �6    � RowDefinitions 5   
   �� 5      $
��163* �6   �� 5      $	��50* �6   �� 5      $��24 �6   �� 5      $
��184* �6   .+�5   
   G� -   5         G�Name$ txtPin��5      $��1��6&   $��
7,22,18,10q�66   $��Center=�6J   $��18��6e   $��1��6q    G� 	MaxLength$ 4��6~   �� 5   
   $��	Enter PIN��6   $��Right=�6$   $��0,116,78,18q�6@   $��60��6�   $��1��6�    �� Target 6U   ��  �� ElementName$ txtPassword��6�   � 5   
   $��1��6   $��2��6$   $��0,0,10,0q�61   .+�5      �� -   5        	 ��Name$	 btnOk��5      $	��_OK��6$   $��70��62   $	��5,2q�6=   
 �� 	IsDefault
 . 6\   �� 5      -   5        $	 	btnCancel��5      $��_Cancel��6(   $��70��6:   $��45,2,0,2q�6E    �� IsCancel . 6h   5      �� 5    
   $��CDI BANK ATM��6   $��Right=�6'   $��0,10,193,124q�6C   $	��104��6�    J� RenderTransformOrigin$ -0.405,1.214&�6�    6Y   �� $ txtPassword��6�   5!      5"      