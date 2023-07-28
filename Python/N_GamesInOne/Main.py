import pygame as py
win = py.display.set_mode((500, 500))
from Pong import Play_Pong
from Snake import Play_Snake
from Simon import Play_Simon
from Brick_Breaker import Play_Brick_Breaker
from Classes import Text

if __name__ == "__main__":
    py.init()
    Text.DefualtSize(50)
    Texts = [Text("Select Game", (0,0)),Text("Play Snake", (0, 30)), Text("Play Pong", (0, 60)), Text("Play Simon", (0, 90)), Text("Play Brick Breaker", (0,120))]
    Selected = None
    Games = {
        "Play Snake" : Play_Snake,
        "Play Pong" : Play_Pong,
        "Play Simon" : Play_Simon,
        "Play Brick Breaker" : Play_Brick_Breaker
    }
    for x in Texts:
        win.blit(*x.CenteredX)
    py.display.update()
    while True:
        for ev in py.event.get():
            if ev.type == py.QUIT:
                py.quit()
                exit()
            if ev.type == py.MOUSEBUTTONDOWN:
                for x in Texts[1:]:
                    S = x.Touching(py.mouse.get_pos())
                    if(S != None):
                        Selected = S
                        break
                    
                    Selected = None
        if(Selected != None):
            while True:
                State = Games[Selected](win)
                if(State == -1): break
                if(State == -2): 
                    py.quit()
                    exit()
            win.fill((0,0,0))
            for x in Texts:
                win.blit(*x.CenteredX)
            py.display.update()
            Selected = None
