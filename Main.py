from Search_Algorithms import DFS

#trạng thái ban đầu
n = int(input("Nhập cấp độ bài toán n\n"))
print("Cấp độ" ,n,"*",n, "puzzle")
root = []
for i in range(0,n*n):
    p = int(input())
    root.append(p)
print("Trạng thái ban đầu:", root)

#Đếm số lần đảo ngược
def inv_num(puzzle):
    inv = 0
    for i in range(len(puzzle)-1):
        for j in range(i+1 , len(puzzle)):
            if (( puzzle[i] > puzzle[j]) and puzzle[i] and puzzle[j]):
                inv += 1
    return inv

#Kiểm tra xem câu đố có giải được không: Số lần nghịch đảo phải là số chẵn
def solvable(puzzle):
    inv_counter = inv_num(puzzle)
    if (inv_counter %2 ==0):
        return True
    return False

#1,8,2,0,4,3,7,6,5 giải được 
#2,1,3,4,5,6,7,8,0 không giải được

from time import time

if solvable(root):
    print("Đang tìm lời giải!\n")
    time2 = time()
    DFS_solution = DFS(root, n)
    DFS_time = time() - time2
    print('Lời giải theo thuật toán DFS: ', DFS_solution[0])
    print('Số nút sinh ra: ', DFS_solution[1])
    print('Thời gian chạy thuật toán:', DFS_time, "\n")      
else:
    print("Không có lời giải!")



     