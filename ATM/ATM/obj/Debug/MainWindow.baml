   M S B A M L   `   `   `  ����>  :ATM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ATMATM  5   	       ATM.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:ATM     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�6Z   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��117* �6   �� 5      $
��192* �6   �� 5      $
��176* �6   �� 5      $
��192* �6   �� 5      $
��117* �6   .+�5   
   �� $��	Main Menu��6   $��2��6$   $��0,37,0,0q�64   $	��Top=�6F   $
��Bold"�6^   $��16(�6p   $��Center=�6~   �� 5   
   -   5        $��Deposit��5      $��3��6#   $��0,91,0,0q�63   $	��Top=�6E   6]   �� 5   
   -   5        $��
Withdrawal��5      $��3��6&   $��	0,157,0,0q�66   $	��Top=�6I   6a   �� 5   
   -   5        $��Transfer Money��5      $��1��6*   $��0,91,0,0q�6:   $	��Top=�6L   6d   �� 5   
   -   5        $��Bill Payment��5      $��1��6(   $��	0,157,0,0q�68   $	��Top=�6K   6c   �� 5   
   -   5        $��Show Balance��5      $��3��6(   $��	0,219,0,0q�68   $	��Top=�6K   6c   �� 5   
   -   5        $
��Exit��5      $��1��6    $��	0,219,0,0q�60   $	��Top=�6C   6[   �� 5   
   -   5         ��Name$ listBoxBalance��5      $��2��6*   $
��Left=�6:   $��	80,91,0,0q�6U   $	��Top=�6h   $��86��6�    �� DisplayMemberPath$ BalanceString��6�   $��0,1,1,1q�6�   $	��148��6�   ��6�   �� 6�   �� 5   
   -   5        $ listBoxType��5      $��2��6'   $
��Left=�67   $��	10,91,0,0q�6R   $	��Top=�6e   $��70��6}   $ accountTypeCode��6�   $��1,1,0,1q�6�   $	��148��6�   ��6�   �� 6�   5      5      