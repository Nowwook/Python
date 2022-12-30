from math import radians

pi = 3.141592

def num_input():
    output = input("숫자 입력")
    return float(output)

def get_circumferense(radius):
    return 2 * pi * radius

def get_circle_area(radius):
    return pi * radius * radius

print(__name__)  # 터미널로 검증

# 검증용
# 모듈 자체를 실행하면 __name__은 __main__에 들어감
# 다른 프로그램에서 인포트하면 __name__은 파일명(test_module)이 들어감 
if __name__ == "__main__":    #_2개 
    radius = num_input()
    print(get_circumferense(radius))
    print(get_circle_area(radius))
