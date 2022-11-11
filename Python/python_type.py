# 데이터 타입
v_str1 = "Niceman"    # str
v_str2 = "Goodgirl"   # str

v_bool = True     # bool

v_float = 10.3    # float
v_int = 7         # int

v_complex = 3 + 3j  # complex

v_dict = {
    "name" : "Jang",
    "age" : 32,
    "city" : "seoul"
}                     # dict

v_list = [3,5,7]      # list

v_tuple = 3,5,7       # tuple

v_set = {7,8,9}       # set

print(type(v_str1))     # <class 'str'>
print(type(v_str2))     # <class 'str'>

print(type(v_bool))     # <class 'bool'>

print(type(v_float))    # <class 'float'>
print(type(v_int))      # <class 'int'>

print(type(v_complex))  # <class 'complex'>

print(type(v_dict))     # <class 'dict'> 

print(type(v_list))     # <class 'list'>

print(type(v_tuple))    # <class 'tuple'>

print(type(v_set))      # <class 'set'>

"""
리스트는 []
튜플은 ()
 리스트는 요소의 생성, 삭제, 수정이 가능
 튜플은 그 값을 바꿀 수 없음
 튜플은 인덱싱, 슬라이싱, 더하기, 곱하기, 길이구하기 등 가능
 덧셈은 튜플끼리도 가능하지만, 곱셈은 튜플에 숫자를 곱해서만 가능(튜플끼리 곱셉 안됨)
 튜플이 1개의 값을 갖고 있다면 값 뒤에 콤마(,)를 찍어줘야하고, ()를 생략해도 가능
"""
