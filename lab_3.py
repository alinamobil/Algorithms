# -*- coding: utf-8 -*-
"""
Created on Sat May 22 20:07:00 2021

@author: Mikhail
"""

import random
import numpy as np
import math

def f(vec):
    x=vec[0];    y=vec[1];     z=vec[2];
    u=vec[3];    w=vec[4]
    return x*y*z + x*y*z**2 + y + u*x*y**2*z**2 + w**2*x*y**2*z

def getRez(vec):
    rez = []
    for i in range(len(vec)):
        rez.append([math.fabs(-50-f(vec[i])), i])
    return list(rez)

def getBest(vec, rez, K):
    best = []
    for i in range(K):
        best.append(vec[rez[i][1]])      
    return list(best)

def crossing(vec1, K):
    rez = []    
    for i in range(len(vec)):
        a = random.randint(0,K-1)
        b = random.randint(0,K-1)
        while (a==b):
            b = random.randint(0,K-1)
        rezVec = []
        for k in range(5):
            if (random.random()<0.5):
                rezVec.append(vec1[a][k])
            else:
                rezVec.append(vec1[b][k])
        rez.append(rezVec)
    return rezVec

def mutationBad(vec1):
    for k in range(5):
        if (random.random()<0.2):
            vec1[k] = random.randint(-300,300)
    return vec1
    
def mutationGood(vec1):
    for k in range(5):
        if (random.random()<0.01):
            vec1[k] = random.randint(-300,300)
    return vec1

N = 100
K = 50

MIN = 1000000
for itNum in range(5):
    vec = np.array([[random.randint(-300,300) for i in range(5)] for k in range(N)])
    rez = getRez(vec)       
    rez.sort()
    best = getBest(vec, rez, K)
    '''
    avGen = 0
    for a in rez:
        avGen += a[0] 
        
    if (rez[0][0] <MIN):
        MIN = rez[0][0]
    if (rez[0][0] == 0):
        break
    print("minGen: {}\tavGen: {}".format(rez[0][0],  avGen/N))
    '''
    print("minGen: {}".format(rez[0][0]))
    cross = []
    
    for i in range(100):
        a = random.randint(0,K-1)
        b = random.randint(0,K-1)
        while (a==b):
            b = random.randint(0,K-1)
        cross.append(crossing(best[a], best[b]))
    
    crossRez = getRez(cross)    
    ###########################################    
    ## мутация
    crossRez.sort()
    crossBest = getBest(cross, crossRez, len(cross))
    
    for i in range(100):
        if (i<50):
            crossBest[i] = mutationGood(crossBest[i])
        else: 
            crossBest[i] = mutationBad(crossBest[i])
    ########################################
    ## выбор лучших после мутации
    crossRez = getRez(crossBest)   
        
    crossRez.sort()
    for i in range(50):
        best.append(crossBest[crossRez[i][1]])
    
    vec = best
    

    
    
    
    

    


