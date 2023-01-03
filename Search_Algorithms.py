from State import State
from queue import LifoQueue

#Depth-first Search 
def DFS(given_state , n): 
    root = State(given_state, None, None, 0, 0)
    if root.test():
        return root.solution()
    #Đưa root vào hàng đợi (Vào sau ra trước)
    frontier = LifoQueue()
    frontier.put(root)
    explored = []
    
    while not(frontier.empty()):
        current_node = frontier.get()
        #Độ sâu hiện tại
        max_depth = current_node.depth 
        explored.append(current_node.state)
        
        #Đi đến nhánh tiếp theo
        if max_depth == 30:
            continue 

        children = current_node.expand(n)
        for child in children:
            if child.state not in explored:
                if child.test():
                    return (child.solution(), len(explored))
                frontier.put(child)
    return (("Không tìm thấy lời giải ở độ sâu hiện tại!"), len(explored))
        
    
    

