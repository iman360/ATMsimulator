   M S B A M L   `   `   `  ����>  :ATM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ATMATM  5   	       ATM.Deposit   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:ATM     5   	     � Title$  Deposit��5   	   $	��450��6   $	��800��6&    � WindowStartupLocation$ CenterScreen=�62    � 
ResizeMode$ NoResize=�6W   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��300* �6   �� 5      $
��235* �6   �� 5      $
��300* �6   .+�5   
   �� -   5         ��Name$ accountList��5      $��1��6(   $
��Left=�68   $��	5,106,0,0q�6S   $	��Top=�6f   $	��214��6~   $��31��6�    �� DisplayMemberPath$ accountTypeCode��6�   ��6�   �� 6�   �� 5   
   $��Select Account:��6   $��1��6*   $��
6,66,4,318q�6:   $��Center=�6N   $	��213��6i   $��14(�6u   $��Center=�6�   $��35��6�   �� 5   
   -   5        $��Deposit��5      $��1��6#   $
��Left=�63   $��	5,234,0,0q�6N   $	��Top=�6a   $	��214��6y   $��43��6�   6�   �� 5   
   -   5        $��Back To Menu��5      $
��Left=�6(   $	��Top=�6C   $	��100��6[   $��38��6g   $��	10,10,0,0q�6s   6�   �� 5   
   -   5         ��Name$ 	amountTxt��5      $��1��6%   $
��Left=�65   $��31��6P   $��
81,168,0,0q�6\    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $	��138��6�   $��14(�6�   �� 5   
   $��Amount :��6   $
��Left=�6#   $��	0,168,0,0q�6>   $	��Top=�6Q    J� RenderTransformOrigin$ 0.022,0.068&�6i   $��76��6�   $��16(�6�   $��31��6�   $��1��6�   5      5      