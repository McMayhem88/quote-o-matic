   M S B A M L   `   `   `  ����G  CQuoteProgWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuoteProgWPFQuoteProgWPF  5   	       QuoteProgWPF.ItemWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuoteProgWPF     5   	   -   5          � Title$  
ItemWindow��5	   	   #��� ��6   $	��450��6h   $	��450��6x   $	��450��6�   $	��450��6�   .��5
      �  � RowDefinitions 5   
   �� 5      $
��117* �6   �� 5      $	��175 �6   $	��175��6)   $	��175��69   �� 5      $��35 �6   $��35��6(   $��35��67   .+�5   
   �� $��	Item Info��6   $��5q�6&   ���	#FF818181.��5      �  5      �� 5      $��30��6$   $��30��63   �� 5      $��30��6$   $��30��63   �� 5      �� 5      �� 5      $��30��6$   $��30��63   �� 5      $��30��6$   $��30��63    � ColumnDefinitions 5      �� 5      $��95��6'   $��95��65   �� 5      .+�5      �� $��0��6   $��0��6(   $��Part Number��65   $��0,0,5,0q�6K   $��Center=�6]   $	��0,5q�6x   $��Right=�6�   $��Center=�6�   �� 5       -   5         ��Name$ 
tb_it_name��5       $��1��6.   $��0��6>   $��23��6K    �� TextWrapping$
 Wrap=�6W   $	��5,0q�6k   6x   �� 5"      $��0��6   $��1��6(   $��Description��65   $��0,0,5,0q�6K   $��Center=�6]   $	��0,5q�6x   $��Right=�6�   $��Center=�6�   �� 5#      -   5        $ 
tb_it_desc��5#      $��1��6.   $��1��6>   $��3��6K   $
 Wrap=�6\   $��5q�6p    �� AcceptsReturn .  J� 	AllowDrop . 6�   �� 5%      $��0��6   $��4��6(   $	��U/M��65   $��0,0,5,0q�6C   $��Center=�6U   $	��0,5q�6p   $��Right=�6}   $��Center=�6�   �� 5&      -   5        $ 	tb_it_uom��5&      $��1��6-   $��4��6=   $��23��6J   $
 Wrap=�6V   $	��5,0q�6j   $	��100��6w   $
��Left=�6�   $��EA��6�   �� 5(      $��0��6   $��5��6(   $��Quantity��65   $��0,0,5,0q�6H   $��Center=�6Z   $	��0,5q�6u   $��Right=�6�   $��Center=�6�   �� 5)      -   5        $ 	tb_it_qty��5)      $��1��6-   $��5��6=   $��23��6J   $
 Wrap=�6V   $	��5,0q�6j   $	��100��6w   $
��Left=�6�   $��1��6�   6�   5*      5,      �� 5-   
   $��Pricing Info��6   $��5q�6)   $��1��64   ���	#FF818181.��5.      �� .+�5/      �� $��Calculate Net Price��6   $��75��68   ���	#FF818181.��5=      �  5>      �� 5?      $	��120��6/   �� 5@      $��5��6/   �� 5A      $	��120��6/   �� 5B      $��5��6/   �� 5C      $	��100��6/   .+�5E      �� $��0��6%   .+�5F      �� $��
List Price��6$   $��5,5,5,0q�69   $��Bottom=�6K   $��0,5,0,0q�6f   $��Center=�6w   �� 5G      -   5        $ tb_calc_list��5G   &   $��23��6<   $
 Wrap=�6H   $��$0.00��6\   $	��100��6i   6u   5H      �� 5I      $��2��6%   .+�5J      �� $��Discount��6$   $��5,5,5,0q�67   $��Bottom=�6I   $��0,5,0,0q�6d   $��Center=�6u   �� 5K      -   5        $ tb_calc_discount��5K   &   $��23��6@   $
 Wrap=�6L   $��0%��6`   $	��100��6j   6v   5L      �� 5M      -   5        $��	Calculate��5M   !   $��4��65   $��Right=�6E   $��Bottom=�6a   $	��100��6|   $��Center=�6�   6�   5N      5O      � 5P      $��60��6   $��5,5,5,0q�6#    5Q      �� 5R      �� 5S       5U      �� 5V      $��65��6+   $��65��69   �� 5W      $	��115��6+   $	��115��6:   �� 5X      $��5��6+   �� 5Y      $��65��6+   $��65��69   �� 5Z      $	��115��6+   $	��115��6:   .+�5^      �� $��0��6   $��0��6,   $��	Net Price��69   $��0,0,5,0q�6M   $��Center=�6_   $	��0,5q�6z   $��Right=�6�   $��Center=�6�   �� 5_      $��0��6   $��1��6,   $��Markup��69   $��0,0,5,0q�6J   $��Center=�6\   $	��0,5q�6w   $��Right=�6�   $��Center=�6�   �� 5a      $��3��6   $��0��6,   $��
Sell Price��69   $��0,0,5,0q�6N   $��Center=�6`   $	��0,5q�6{   $��Right=�6�   $��Center=�6�   �� 5b      $��3��6   $��1��6,   $��Profit��69   $��0,0,5,0q�6J   $��Center=�6\   $	��0,5q�6w   $��Right=�6�   $��Center=�6�   �� 5d      -	   5        $ 	tb_it_net��5d      $��1��61   $��0��6A   $��23��6N   $
 Wrap=�6Z   $��$0.00��6n   $	��100��6{   $
��Left=�6�   $��5,0,0,0q�6�   6�   �� 5e      -
   5        $ tb_it_markup��5e      $��1��64   $��1��6D   $��23��6Q   $
 Wrap=�6]   $��0%��6q   $	��100��6{   $
��Left=�6�   $��5,0,0,0q�6�   6�   �� 5g      -   5        $ 
tb_it_sell��5g      $��4��62   $��0��6B   $��23��6O   $
 Wrap=�6[   $��$0.00��6o   $	��100��6|   $
��Left=�6�   $��5,0,0,0q�6�   ���	#FFD4D4D4���	#FF7C7C7C���	#FF515151|�.   J� IsHitTestVisible .   .  6%  �� 5h      -   5        $ tb_it_profit��5h      $��4��64   $��1��6D   $��23��6Q   $
 Wrap=�6]   $��$0.00��6q   $	��100��6~   $
��Left=�6�   $��5,0,0,0q�6�   ���	#FFD4D4D4���	#FF7C7C7C���	#FF515151|�.   .   .  6'  5j      5k      5l      �� 5m   
   -   5        $��Add Item��5m      $��0,3,3,3q�6$   $��2��65   $��Right=�6B   $��95��6^   6i   �� 5n   
   -   5        $��Cancel��5n      $��3,3,0,3q�6"   $��2��63   $
��Left=�6@   $��95��6[   6f   5o      5p      