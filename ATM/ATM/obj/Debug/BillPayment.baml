   M S B A M L   `   `   `  ����>  :ATM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ATMATM  5   	       ATM.BillPayment   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:ATM     5   	     � Title$  BillPayment��5   	   $	��450��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��290* �6   �� 5      $
��232* �6   �� 5      $
��290* �6   .+�5   
   �� -   5        $��Back To Menu��5      $
��Left=�6(   $	��Top=�6C   $	��100��6[   $��38��6g   $��	10,10,0,0q�6s   6�   �� 5   
   -   5        $	��PAY��5      $
��Left=�6   $��290,234,0,0q�6:   $	��Top=�6O   $	��214��6g   $��43��6s   $��3��6�   �� 5   
   -   5         ��Name$ 	amountTxt��5      $��1��6%   $
��Left=�65   $��31��6P   $��
10,168,0,0q�6\    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $	��204��6�   $��14(�6�   $��	123456789��6�   �� 5   
   $��Bill Number��6   $
��Left=�6&   $��
58,117,0,0q�6A   $	��Top=�6U    J� RenderTransformOrigin$ 0.022,0.068&�6m   $	��101��6�   $��16(�6�   $��31��6�   $��1��6�   5      5      