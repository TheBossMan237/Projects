from typing import Any
import pygame as py
from random import random
from math import pi, cos, sin
from time import sleep, time
from Classes import Text
py.init()
class P_Paddle(py.sprite.Sprite):
    def __init__(self):
        py.sprite.Sprite.__init__(self)
        self.image = py.Surface((20, 100))
        self.image.fill((255, 255, 255))
        self.rect = self.image.get_rect()
        self.Keys = {py.K_w : False, py.K_s : False}
        self.Speed = .1
        self.X = 5
        self.Y = 250
    def KeyDown(self, Key):
        try: 
            self.Keys[Key] = True

        except: pass
    def KeyUp(self, Key):
        try: self.Keys[Key] = False
        except : pass
    def update(self) -> None:
        if(self.Keys[py.K_s] and self.Y < 400): self.Y += self.Speed
        if(self.Keys[py.K_w] and self.Y > 0): self.Y -= self.Speed 
        self.rect.x = self.X
        self.rect.y = self.Y
        return self.X, self.Y
class B_Paddle(py.sprite.Sprite):
    def __init__(self, IsPlayer = 1):
        py.sprite.Sprite.__init__(self)
        self.IsPlayer = IsPlayer
        self.Keys = {py.K_DOWN : False, py.K_UP : False}
        self.image = py.Surface((20, 100))
        self.image.fill((255, 255, 255))
        self.rect = self.image.get_rect()
        self.Speed = .05
        self.Ball = None
        self.X = 470
        self.Y = 250
    def KeyDown(self, Key : int):
        if(self.IsPlayer == 2): self.Keys[Key] = True
    def KeyUp(self, Key : int):
        if(self.IsPlayer == 2): self.Keys[Key] = False
    def update(self):
        self.rect.x = self.X
        self.rect.y = self.Y
        if(self.IsPlayer == 2):
            if(self.Keys[py.K_UP] and self.Y > 0): self.Y -= self.Speed * 2
            if(self.Keys[py.K_DOWN] and self.Y < 400): self.Y += self.Speed * 2
        else:
            if(self.Ball.Y > self.Y and self.Y < 400): self.Y += self.Speed
            if(self.Ball.Y < self.Y and self.Y > 0): self.Y -= self.Speed
        return self.X, self.Y
class Ball(py.sprite.Sprite):
    def __init__(self, Player1, Player2, scores):
        py.sprite.Sprite.__init__(self)
        self.image = py.Surface((25, 25))
        py.draw.circle(self.image, (255, 255, 255), (12, 12), 12)
        self.P1 = Player1
        self.P2 = Player2
        self.S =scores
        self.S.update()
        self.P2.Ball = self
        self.rect = self.image.get_rect()
        self.X = 250
        self.Y = 250
        self.Speed = .1
        self.Vel = py.Vector2(0, 0)
        self.Angle = 0
    def RandomDir360(self):
        self.Angle = pi*random()
        self.Vel.x = cos(self.Angle)
        self.Vel.y = sin(self.Angle)
        self.Vel*=self.Speed
    def RandomDir180(self, IsP1 = True):

        self.Angle = (pi*random())/2
        if IsP1: self.Vel.x = cos(self.Angle)
        else: self.Vel.x = -cos(self.Angle)
        self.Vel.y = sin(self.Angle)
        self.Vel*=self.Speed
    def Reflect(self, axis=0):
        match axis:
            #Along Y 
            case 0: 
                self.Vel.y *= -1
                self.Y += self.Vel.y

            #Along X
            case 1: 
                if(self.X >= 0):

                    self.S.Scores[0] +=1
                if(self.X < 400):
                    self.S.Scores[1] += 1
                self.S.update()
                self.X = 250
                self.Y = 250
                self.RandomDir360()

    def update(self):
        self.rect.x = self.X
        self.rect.y = self.Y
        if(self.rect.colliderect(self.P1)):
            self.RandomDir180(True)
        if(self.rect.colliderect(self.P2)):
            self.RandomDir180(False)
        if(self.Y > 0 and self.Y < 475): self.Y += self.Vel.y
        else: self.Reflect(0)
        if(self.X > 0 and self.X < 475): self.X += self.Vel.x
        else: self.Reflect(1)
        
        return self.X, self.Y


        
class Score(py.sprite.Sprite):
    def __init__(self):
        py.sprite.Sprite.__init__(self)
        self.image = py.Surface((500, 50))
        self.Font = py.font.Font(None, 40)
        self.Scores = [0, 0]
        self.Offset = 100
        
    def update(self):
        self.image.fill((0,0,0))        
        self.image.blit(self.Font.render(str(self.Scores[0]), True, (255, 255, 255)), (self.Offset, 0))
        self.image.blit(self.Font.render(str(self.Scores[1]), True, (255, 255, 255)), (500 - self.Offset, 0))
    def Change_P1(self, amount):
        self.Scores[0]+=1



def Main(win : py.Surface, PlayerCount : int):
    Scores = Score()
    Player = P_Paddle()
    Bot = B_Paddle(PlayerCount)
    ball = Ball(Player, Bot, Scores)
    
    Divider = py.Surface((10, 500))
    for x in range(0, 500, 50):
        py.draw.rect(Divider, (255, 255, 255), (0, x, 10, 40))
    ball.RandomDir360()

    
    while True:
        win.fill((0,0,0))
        for ev in py.event.get():
            match(ev.type):
                case py.QUIT: return -2
                case py.KEYDOWN: 
                    if ev.key == py.K_w or ev.key == py.K_s: Player.KeyDown(ev.key)
                    if PlayerCount == 2 and (ev.key == py.K_UP or ev.key == py.K_DOWN): Bot.KeyDown(ev.key)
                    if ev.key == py.K_q: return -1
                case py.KEYUP: 
                    if ev.key == py.K_w or ev.key == py.K_s: Player.KeyUp(ev.key)
                    if PlayerCount == 2 and (ev.key == py.K_UP or ev.key == py.K_DOWN): Bot.KeyUp(ev.key)

        Pl_Pos = Player.update()
        Ba_Pos = ball.update()
        Bo_Pos = Bot.update()
        win.blit(Player.image, Pl_Pos)
        
        win.blit(Bot.image, Bo_Pos)
        
        win.blit(Scores.image, (0, 25))
        win.blit(Divider, (250, 0))
        win.blit(ball.image, Ba_Pos)
        py.display.flip()

def Main_Menu(win : py.Surface):
    win.fill((0,0,0))
    Texts = [Text("Pong",(0, 0)), Text("1P", (0, 50)), Text("2P", (0, 80))]
    for x in Texts:
        win.blit(*x.CenteredX)
    py.display.update()
    while True:
        for ev in py.event.get():
            match ev.type:
                case py.QUIT: return -2
                case py.MOUSEBUTTONDOWN:
                    for x in Texts:
                        X = x.Touching(py.mouse.get_pos())
                        if(X == "1P"):
                            return 1
                        if(X == "2P"):
                            return 2
                case py.KEYDOWN:
                    if ev.key == py.K_q:
                        return -1




    
def Play_Pong(win : py.Surface):
    PlayerCount = 1
    while True:
        State = Main_Menu(win)
        if(State < 0): return State
        else: PlayerCount = State
        State = Main(win, PlayerCount)
        if(State == -1): return State



    
