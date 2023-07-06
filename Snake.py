import pygame as py
from random import randint
from Classes import Text

py.init()
from time import sleep
EV_FRUIT_EATEN = py.USEREVENT+1
class Snake:
    def __init__(self, win : py.Surface):
        self.S = [[250, 250], [225, 250]]
        self.Score = 0
        self.GameOver = False
        self.Fruit = [[randint(0, 20)*25, randint(0, 20)*25] for i in range(10)]
        self.win = win
    def Draw(self):
        for x in self.S:
            py.draw.rect(self.win, (0, 255, 0), (x[0], x[1], 25, 25))
        for x in self.Fruit:
            py.draw.rect(self.win, (255, 0, 0), (x[0], x[1], 25, 25))
    def Move(self, Dir : int):
        OnFruit = False
        for x in range(0, len(self.Fruit)):
            if self.Fruit[x] == self.S[0]:
                self.Fruit[x] = [randint(0, 20)*25, randint(0, 20)*25]
                OnFruit = True
                self.Score += 1 
                break
        if OnFruit: 
            self.S.append(self.S[0].copy())
        else:
            for x in range(len(self.S)-1, 0, -1):
                self.S[x] = self.S[x-1].copy()
            match Dir:
                case 0:
                    if self.S[0][1] > 0:
                        self.S[0][1] -= 25
                case 1:
                    if self.S[0][0] < 475:
                        self.S[0][0] += 25
                case 2:
                    if self.S[0][1] < 475:
                        self.S[0][1] += 25
                case 3:
                    if self.S[0][0] > 0: 
                        self.S[0][0] -= 25
                
            for x in range(0, len(self.S)-1):
                if(self.S.count(self.S[x]) != 1):
                    self.GameOver = True
    def Reset(self):
        self.S = [[250, 250], [225, 250]]
        self.Score = 0
        self.GameOver = False
        self.Fruit = [[randint(0, 20)*25, randint(0, 20)*25] for i in range(10)]
    def __str__(self):
        return str(self.Score)




def Main(win : py.Surface):

    Dir = 0
    X, Y = 25, 25
    mx, my = 0, 0
    while True:
        win.fill((0,0,0))
        for ev in py.event.get():
            if ev.type == py.QUIT:
                return -2
            if ev.type == py.MOUSEMOTION:
                mx, my = ev.pos
            if ev.type == py.KEYDOWN:
                if ev.key == py.K_w and Dir != 2:
                    Dir = 0
                if ev.key == py.K_d and Dir != 3:
                    Dir = 1
                if ev.key == py.K_s and Dir != 0:
                    Dir = 2
                if ev.key == py.K_a and Dir != 1:
                    Dir = 3
                if ev.key == py.K_q: 
                    return -1
            if ev.type == py.USEREVENT:
                if S.GameOver:
                    return 1
                S.Move(Dir)

            if ev.type == EV_FRUIT_EATEN:
                pass
        S.Draw()
        py.display.flip()
def Game_Over(win : py.Surface):
    Text.DefualtSize(50)
    Texts = [Text("Game Over!", (0,0)), Text(f"Score - {S}", (0, 30)), Text("Space - Try Again", (0,60)), Text("q - To Main Menu", (0, 90))]
    for x in Texts:
        win.blit(*x.Rend)
    S.Draw()
    py.display.flip()
    while True:

        for ev in py.event.get():
            if ev.type == py.QUIT:
                return -2
            if ev.type == py.KEYDOWN:
                if ev.key == py.K_SPACE:
                    S.Reset()
                    return 1
                else:
                    return -2
def Play_Snake(win : py.Surface):
    py.time.set_timer(py.USEREVENT, 100)
    global S
    S = Snake(win)
    while True:
        State = Main(win)
        if(State < 0): return State
        State = Game_Over(win)
        if(State < 0): return State
