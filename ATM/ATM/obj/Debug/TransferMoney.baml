   M S B A M L   `   `   `  ����>  :ATM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ATMATM  5   	       ATM.TransferMoney   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:ATM     5   	     � Title$  TransferMoney��5   	   $	��450��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ NoResize=�6]   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��109* �6   �� 5      $	��30* �6   �� 5      $	��90* �6   �� 5      $
��190* �6    � ColumnDefinitions 5   
   �� 5      $
��191* �6   �� 5      $
��128* �6   �� 5      $
��155* �6   �� 5      $
��128* �6   �� 5      $
��209* �6   .+�5   
   �� $��From :��6   $
��Left=�6!   $��	120,1,0,0q�6<   $��1��6O   $	��Top=�6\    J� RenderTransformOrigin$ 0.022,0.068&�6t   $��56��6�   $��16(�6�   $��29��6�   �� 5   
   $
��To :��6   $
��Left=�6   $��	103,1,0,0q�6:   $��1��6M   $	��Top=�6Z   $ 0.022,0.068&�6r   $��38��6�   $��16(�6�   $��2��6�   $��33��6�   $��2��6�   �� 5   
   -   5         ��Name$ 	amountTxt��5      $��2��6%   $
��Left=�65   $��31��6P   $��	10,28,0,0q�6\   $��2��6o    �� TextWrapping$
 Wrap=�6|   $	��Top=�6�   $	��125��6�   �� 5   
   $��Amount :��6   $
��Left=�6#   $��	39,28,0,0q�6>   $��2��6Q   $	��Top=�6^   $ 0.022,0.068&�6v   $��76��6�   $��16(�6�   $��1��6�   $��31��6�   �� 5   
   $��Transfer Money��6   $��	0,46,0,29q�6)   $��Center=�6<   $ 0.022,0.068&�6W   $	��151��6{   $��18(�6�   $��2��6�   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   $��34��6�   �� 5   
   -   5        $��Transfer��5      $��2��6$   $
��Left=�64   $��3��6O   $	��Top=�6\   $	��125��6t   $��38��6�   $��10,0,0,0q�6�   6�   �� 5   
   -   5        $��Back To Menu��5      $
��Left=�6(   $	��Top=�6C   $	��100��6[   $��38��6g   $��	10,10,0,0q�6s   6�   �� 5   
   -   5         ��Name$ accountList1��5      $
��Left=�6)   $��3,2,0,0q�6D   $	��Top=�6U   $	��120��6m   $��26��6y   	 �� DisplayMemberPath$	 accountTypeCode��6�   $��1��6�   $��1��6�   ��6�   �� 6�   �� 5   
   -   5        $ accountList2��5      $
��Left=�6)   $	��Top=�6D   $	��121��6\   $��27��6h   $	 accountTypeCode��6�   $��1��6�   $��3��6�   $��2,2,0,0q�6�   ��6t   �� 6�   5!      5"      