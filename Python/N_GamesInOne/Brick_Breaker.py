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
    for x in range(50, 401, Width):
        for y in range(50, 201, Height):
            List.append([py.Rect(x, y, Width, Height), True])

class Ball:
    Speed = 2
    Radius = 10
    Rect = py.Rect(250-Radius, 250-Radius, 2*Speed*Radius, 2*Speed*Radius)
    CX, CY, = 250, 250
    Angle = random()*pi
    Vel = py.Vector2(Speed*cos(Angle), Speed*sin(Angle))
    
    GameOver = False
    @classmethod 
    def Move(cls):
        if cls.CX > 500-cls.Radius:
            cls.Vel.reflect_ip(py.Vector2(1, 0))
        if cls.CX < 0+cls.Radius:
            cls.Vel.reflect_ip(py.Vector2(-1, 0))
        if cls.CY > 500-cls.Radius-Paddle.Height:
            if cls.CY > 500-cls.Radius:
                cls.GameOver = True
            if Paddle.Rect.colliderect(cls.Rect):
                X = (cls.Rect.centerx - Paddle.Rect.centerx)*2 / Paddle.Width
                cls.Vel = py.Vector2(0, -cls.Speed)
                cls.Vel.rotate_rad_ip(-(pi/2)*X)

                
        if cls.CY < 0+cls.Radius:
            cls.Vel.reflect_ip(py.Vector2(0, -1))
        cls.CX += cls.Vel.x
        cls.CY += cls.Vel.y
        cls.Rect.center = (cls.CX, cls.CY)
    @CLS_Prop
    def Center(cls):
        return (Ball.CX, Ball.CY)
    @classmethod
    def Bounce(cls, Rect : py.Rect):
        
        if cls.Vel.y > 0:
            cls.Vel.reflect_ip(py.Vector2(0, 1))
            print("Top")
        if cls.Vel.y < 0:
            cls.Vel.reflect_ip(py.Vector2(0, -1))
            print("Bottom")
        if cls.Vel.x > 0 :
            cls.Vel.reflect_ip(py.Vector2(1, 0))
            print("Right")
        if cls.Vel.x < 0:
            cls.Vel.reflect_ip(py.Vector2(-1, 0))
            print("Left")

    @CLS_Prop
    def S_Rect(cls):
        X = cls.Rect.copy()
        X.size = (cls.Radius*2, cls.Radius*2)
        return X

def Main(win : py.Surface):
    win = py.display.set_mode((500, 500))
    Time = py.time.Clock()    
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
                    continue
                py.display.update(x[0])
        Time.tick(120)
                
                
def Main_Menu(win : py.Surface):

    while True:
        for ev in py.event.get():
            if ev.type == py.QUIT:
                return -2
            if ev.type == py.KEYDOWN:
                if ev.key == py.K_q:
                    return -1
                if ev.key == py.K_SPACE:
                    return 0
                


        
def Play_Brick_Breaker(win):
    while True:
        State = Main_Menu(win)
        if(State < 0): return State
        State = Main(win)
        if(State < 0): return State

py.quit()
