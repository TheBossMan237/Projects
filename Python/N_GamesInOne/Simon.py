import pygame as py
from math import sin, cos, pi
from numpy import arange
from random import choice,randint
from Classes import Text
py.init()



def Game_Over(win, Score):
    win.fill((0,0,0))
    Texts = [Text("Game Over!", (0, 0)), Text(f"Score : {Score}", (0, 30)), Text("Try Again?", (0, 60))]
    for x in Texts:
        win.blit(*x.CenteredX)
    
    py.display.flip()
    while True:
        for ev in py.event.get():
            if ev.type == py.MOUSEBUTTONDOWN and ev.button == 1:
                if Texts[2].Touching(py.mouse.get_pos()) == "Try Again?":
                    print(1)                   
                    return 0

            if ev.type == py.QUIT: return -2
            if ev.type == py.KEYDOWN and py.key == py.K_q: return -1
def Game(win = None):
    py.time.set_timer(py.USEREVENT, 500)
    List = [randint(0,3)]
    Index = 0
    Lock = True
    GameOver = False
    Stop = False
    C = None
    R = None
    mx, my = 0, 0
    py.draw.rect(win, (0, 0, 180), (0, 0, 250, 250))
    py.draw.rect(win, (180, 0, 0), (250, 0, 250, 250))
    py.draw.rect(win, (0, 180, 0), (0, 250, 250, 250))
    py.draw.rect(win, (180, 180, 0), (250, 250, 250, 250))
    py.display.update()
    while True:
        for ev in py.event.get():
            if ev.type == py.QUIT:
                return -2
            if ev.type == py.KEYDOWN:
                if ev.key == py.K_q: return -1
            if ev.type == py.MOUSEBUTTONDOWN and ev.button == 1:
                if Stop:
                    mx, my = py.mouse.get_pos()
                    match List[Index]:
                        case 0: R = (0, 0, 250, 250)
                        case 1: R = (250, 0, 250, 250)
                        case 2: R = (0, 250, 250, 250)
                        case 3: R = (250, 250, 250, 250)
                    if py.Rect(R).collidepoint(mx, my):
                        if Index < len(List)-1: Index += 1
                        else:
                            Index = 0
                            List.append(randint(0, 3))
                            Stop = False

                    else:
                        GameOver = True
            if ev.type == py.USEREVENT:
                if not Stop:
                    if Lock:
                        Lock = False
                        R = None
                        C = None
                        match List[Index]:
                            case 0: 
                                R = (0, 0, 250, 250)
                                C = (0, 0, 255)
                            case 1:
                                R = (250, 0, 250, 250)
                                C = (255, 0, 0)
                            case 2:
                                R = (0, 250, 250, 250)
                                C = (0, 255, 0)
                            case 3:
                                R = (250, 250, 250, 250)
                                C = (250, 250, 0)
                        py.draw.rect(win, C, R)
                        py.display.flip()
                        break
                    else:
                        if Index < len(List)-1: Index += 1
                        else: 
                            Index = 0
                            Stop = True
                        py.display.flip()
                        Lock = True
        if not Lock:
            py.draw.rect(win, (0, 0, 180), (0, 0, 250, 250))
            py.draw.rect(win, (180, 0, 0), (250, 0, 250, 250))
            py.draw.rect(win, (0, 180, 0), (0, 250, 250, 250))
            py.draw.rect(win, (180, 180, 0), (250, 250, 250, 250))
        if GameOver:
            return len(List)
def Play_Simon(win):
    while True:
        State = Game(win)
        if State < 0: return State
        State = Game_Over(win, State)
        if State < 0: return State
