import pygame as py
from math import sin, cos, pi
from random import random
from Classes import *
class CLS_Prop(property):
    def __get__(self, cls, owner):
        return classmethod(self.fget).__get__(None, owner)()
class Paddle:
    Width = 100
    Height = 20
    Rect = py.Rect(0, 500-Height, Width, Height)
class Blocks:
    List = []
    Width = 50
    Height = 25
    Destroyed = 0
    for x in range(50, 401, Width):
        for y in range(50, 201, Height):
            List.append([py.Rect(x, y, Width, Height), True])

class Ball:
    def __init__(self):

        Ball.Speed = 2
        Ball.Radius = 10
        Ball.Rect = py.Rect(250-Ball.Radius, 250-Ball.Radius, 2*Ball.Speed*Ball.Radius, 2*Ball.Speed*Ball.Radius)
        Ball.CX, Ball.CY, = 250, 250
        Ball.Angle = random()*pi/2
        Ball.TouchedRect = False
        Ball.Vel = py.Vector2(Ball.Speed*cos(Ball.Angle + pi/2), Ball.Speed*sin(Ball.Angle + pi/2))
    
    GameOver = False
    @classmethod 
    def Move(cls):
        if cls.CX > 500-cls.Radius:
            cls.Vel.reflect_ip(py.Vector2(1, 0))
            cls.Bounced_X = False
            cls.Bounced_Y = False
            print("Right")
        if cls.CX < 0+cls.Radius:
            cls.Vel.reflect_ip(py.Vector2(-1, 0))
            cls.Bounced_X = False
            cls.Bounced_Y = False
            print("Left")
        if cls.CY > 500-cls.Radius-Paddle.Height:
            if cls.CY > 500-cls.Radius:
                cls.GameOver = True
            if Paddle.Rect.colliderect(cls.Rect):
                X = (cls.Rect.centerx - Paddle.Rect.centerx)*2 / Paddle.Width
                cls.Vel = py.Vector2(0, -cls.Speed)
                cls.Vel.rotate_rad_ip(-(pi/2)*X)
                cls.Bounced_X = False
                cls.Bounced_Y = False

                
        if cls.CY < 0+cls.Radius:
            cls.Vel.reflect_ip(py.Vector2(0, -1))
            cls.Bounced_X = False
            cls.Bounced_Y = True
            print("Top")

        
        cls.CX += cls.Vel.x
        cls.CY += cls.Vel.y
        cls.Rect.center = (cls.CX, cls.CY)
    @CLS_Prop
    def Center(cls):
        return (Ball.CX, Ball.CY)
    @classmethod
    def Bounce(cls, Rect : py.Rect):
        if cls.Vel.x >= 0 and not cls.Bounced_X:
            cls.Vel.reflect_ip(py.Vector2(0, 1))
            cls.Bounced_X = True
            return 
        if cls.Vel.x <= 0 and not cls.Bounced_X:
            cls.Vel.reflect_ip(py.Vector2(0, -1))
            cls.Bounced_X = True
            return
        if cls.Vel.y >= 0 and not cls.Bounced_Y:
            cls.Vel.reflect_ip(py.Vector2(1, 0))
            cls.Bounced_Y = True
        

    @CLS_Prop
    def S_Rect(cls):
        X = cls.Rect.copy()
        X.size = (cls.Radius*2, cls.Radius*2)
        return X

def Main(win : py.Surface):
    Ball()
    win = py.display.set_mode((500, 500))
    Time = py.time.Clock()
    win.fill((0,0,0)) 
    py.display.flip()   
    while True:
        for ev in py.event.get():
            if ev.type == py.QUIT:
                return -2
            if ev.type == py.KEYDOWN:
                match ev.key:
                    case py.K_q: return -1
            if ev.type == py.MOUSEMOTION:
                py.draw.rect(win, (0,0,0), Paddle.Rect)
                py.display.update(Paddle.Rect)
                Paddle.Rect.centerx = py.mouse.get_pos()[0]
        py.display.update(Ball.Rect)
        Ball.Rect = Ball.Rect.move(Ball.Vel)
        py.draw.rect(win, (0,0,0), Ball.Rect)
        Ball.Move()
        py.draw.rect(win, (255, 255, 255), Paddle.Rect)
        py.draw.circle(win, (255, 255, 255), Ball.Center, Ball.Radius)
        py.display.update(Paddle.Rect)
        if(Ball.GameOver):
            return 0
        for x in Blocks.List:
            if x[1]: 
                py.draw.rect(win, (255, 255, 255), x[0])
                py.draw.rect(win, (0,0,0), x[0], 1)
                
                if x[0].colliderect(Ball.S_Rect):
                    Ball.Bounce(x[0])
                    py.draw.rect(win, (0,0,0), x[0])
                    x[1] = False
                    py.display.update(x[0])
                    Blocks.Destroyed += 1
                    if(Blocks.Destroyed == len(Blocks.List)):
                        Ball.Won = True;
                        return 1
                    continue
                py.display.update(x[0])
        Time.tick(120)
                
                
def Main_Menu(win : py.Surface):
    win.fill((0,0,0))
    Ball.GameOver = False
    Ball.Won = False
    Texts = [Text("Play Again?", (0, 50))]
    for x in Texts:
        win.blit(*x.CenteredX)
    py.display.flip()
    while True:
        for ev in py.event.get():
            if ev.type == py.QUIT:
                return -2
            if ev.type == py.KEYDOWN:
                if ev.key == py.K_q:
                    return -1
            if ev.type == py.MOUSEBUTTONDOWN:
                if Texts[0].Touching(py.mouse.get_pos()) == "Play Again?":
                    print(1)
                    return 0


                


        
def Play_Brick_Breaker(win):
    while True:
        State = Main_Menu(win)
        if(State < 0): return State
        State = Main(win)
        if(State < 0): return State
