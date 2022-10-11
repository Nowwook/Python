# 불러오는 방식 2개
import test_module as test
radius = test.num_input()
print(test.get_circumferense(radius))
print(test.get_circle_area(radius))
 

from test_module import *
radius = num_input()
print(get_circumferense(radius))
print(get_circle_area(radius))
