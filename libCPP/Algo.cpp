#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h> 

using namespace std;

Algo::Algo()
{
	srand(time(NULL));
}

Algo::~Algo()
{

}

void Algo::fillMap(TileType map[], int size)
{
	int nbType[NB_TILETYPES] = { 0 };
	int nb_unique_tiles = size / NB_TILETYPES;
	for (int i = 0; i < size; i++)
	{
		// Choose a random tile
		int type = rand() % NB_TILETYPES;

		bool filled(false);
		do{
			// if the number of the tile in the map isn't max
			if (nbType[type] + 1 <= nb_unique_tiles)
			{
				nbType[type]++;
				map[i] = (TileType)(type);
				filled = true;
			}
			else
			{
				// else fill the map with an other tile 
				if (nbType[Plain] + 1 <= nb_unique_tiles) type = Plain;
				else if (nbType[Desert] + 1 <= nb_unique_tiles) type = Desert;
				else if (nbType[Volcano] + 1 <= nb_unique_tiles) type = Volcano;
				else if (nbType[Swamp] + 1 <= nb_unique_tiles) type = Swamp;
				else
					filled = true;
			}
		} while (!filled);
	}
}

void Algo::positionUnits(int positions[], int size)
{
	/*
	________		________
	|X		|		|	   X|
	|		|		|		|
	|______X|		|X______|
	value = 0		value = 1

	*/
	// Position according to the value
	int value = rand() % 2;
	if (value == 0){
		positions[0] = 0;
		positions[1] = 0;
		positions[2] = size - 1;
		positions[3] = size - 1;
	}
	else
	{
		positions[0] = size - 1;
		positions[1] = 0;
		positions[2] = 0;
		positions[3] = size - 1;
	}
}


/*****************************************************************************/
/* Algorithmes Suggestion */
/*****************************************************************************/

void Algo::possibleMoves(TileType map[], char* race, int sizeMap, int x, int y, double * movePoints){
	/*int res[3] = { 0 };
	double tabCost[4] = { 0 };
	int tabRes[4] = { 0 };

	if (race == "Cerberus"){
		while (*movePoints > 0){
			moveCerberusInitial(map, sizeMap, x, y, tabCost, tabRes, movePoints);
		}
	}
	else if (race == "Centaur"){
		moveCentaurInitial(map, sizeMap, x, y, tabCost, tabRes, movePoints);
	}
	else if (race == "Cyclop"){
		moveCyclopInitial(map, sizeMap, x, y, tabCost, tabRes, movePoints);
	}*/


}
/*
void Algo::moveCerberusInitial(TileType map[], int sizeMap, int x, int y, double tabCost[], int tabRes[], double * movePoints)
{
	//Par défaut toute les cases sont inacessibles
	int i, j;
	for (i = 0; i < sizeMap; i++)
	{
		for (j = 0; j < sizeMap; j++)
		{
			tabRes[i*sizeMap + j] = CASE_NONCALCULEE;
		}
	}

	//Les points de déplacements restants sont initialisés à 0
	for (i = 0; i < sizeMap; i++)
	{
		for (j = 0; j < sizeMap; j++)
		{
			tabCost[i*sizeMap + j] = 0;
		}
	}

	//On autorise la case initiale
	if (map[x*sizeMap + y] == Volcano)
	{
		tabRes[x*sizeMap + y] = CASE_OPTIMALE;
	}
	else if (map[x*sizeMap + y] == Swamp)
	{
		tabRes[x*sizeMap + y] = CASE_POSSIBLE_2;
	}
	else if (map[x*sizeMap + y] == Desert)
	{
		tabRes[x*sizeMap + y] = CASE_POSSIBLE_1;
	}
	else if (map[x*sizeMap + y] == Plain)
	{
		tabRes[x*sizeMap + y] = CASE_POSSIBLE_0;
	}
	tabCost[x*sizeMap + y] = *movePoints;

	moveCerberus(map, sizeMap, x, y, tabRes, tabCost);
}

void Algo::moveCerberus(TileType map[], int sizeMap, int x, int y, int tabRes[], double tabMoves[])
{
	//case au dessus
	if (x != 0)
	{
		if (tabRes[(x - 1)*sizeMap + y] == CASE_NONCALCULEE)
		{
			moveCerberusTile(map, sizeMap, x - 1, y, tabRes, tabMoves, &tabMoves[x*sizeMap + y]);
		}
	}

	//case au dessous
	if (x != (sizeMap - 1))
	{
		if (tabRes[(x + 1)*sizeMap + y] == CASE_NONCALCULEE)
		{
			moveCerberusTile(map, sizeMap, x + 1, y, tabRes, tabMoves, &tabMoves[x*sizeMap + y]);
		}
	}


	//case à droite
	if (y != (sizeMap - 1))
	{
		if (tabRes[x*sizeMap + y + 1] == CASE_NONCALCULEE)
		{
			moveCerberusTile(map, sizeMap, x, y + 1, tabRes, tabMoves, &tabMoves[x*sizeMap + y]);
		}
	}


	//case à gauche
	if (y != 0)
	{
		if (tabRes[x*sizeMap + y - 1] == CASE_NONCALCULEE)
		{
			moveCerberusTile(map, sizeMap, x, y - 1, tabRes, tabMoves, &tabMoves[x*sizeMap + y]);
		}
	}
}

void Algo::moveCerberusTile(TileType map[], int sizeMap, int x, int y, int tabRes[], double tabMoves[], double * movePoints)
{
	double *movePt = movePoints;

	if (map[x*sizeMap + y] == Volcano){
		if (*movePt >= 1)
		{
			*movePt--;
			tabRes[x*sizeMap + y] = CASE_OPTIMALE;
			tabMoves[x*sizeMap + y] = std::max(*movePt, tabMoves[x*sizeMap + y]); //on garde le meilleur chemin
		}
		else
		{
			tabRes[x*sizeMap + y] = CASE_NONCALCULEE; //On met non calculé pour permettre à un meilleur chemin d'aboutir
		}
	}
	else if (map[x*sizeMap + y] == Swamp){
		if (*movePt >= 1)
		{
			*movePt--;
			tabRes[x*sizeMap + y] = CASE_POSSIBLE_2;
			tabMoves[x*sizeMap + y] = std::max(*movePt, tabMoves[x*sizeMap + y]);
		}
		else
		{
			tabRes[x*sizeMap + y] = CASE_NONCALCULEE;
		}
	}
	else if (map[x*sizeMap + y] == Desert){
		if (*movePt >= 1)
		{
			*movePt--;
			tabRes[x*sizeMap + y] = CASE_POSSIBLE_1;
			tabMoves[x*sizeMap + y] = std::max(*movePt, tabMoves[x*sizeMap + y]);
		}
		else
		{
			tabRes[x*sizeMap + y] = CASE_NONCALCULEE;
		}
	}
	else if (map[x*sizeMap + y] == Plain){
		if (*movePt >= 1)
		{
			*movePt--;
			tabRes[x*sizeMap + y] = CASE_POSSIBLE_0;
			tabMoves[x*sizeMap + y] = std::max(*movePt, tabMoves[x*sizeMap + y]);
		}
		else
		{
			tabRes[x*sizeMap + y] = CASE_NONCALCULEE;
		}
	}
}


void Algo::moveCentaurInitial(TileType map[], int sizeMap, int x, int y, double tabCost[], int tabRes[], double * movePoints)
{
	//Par défaut toute les cases sont inacessibles
	int i, j;
	for (i = 0; i < sizeMap; i++)
	{
		for (j = 0; j < sizeMap; j++)
		{
			tabRes[i*sizeMap + j] = CASE_NONCALCULEE;
		}
	}

	//Les points de déplacements restants sont initialisés à 0
	for (i = 0; i < sizeMap; i++)
	{
		for (j = 0; j < sizeMap; j++)
		{
			tabCost[i*sizeMap + j] = 0;
		}
	}

	//On autorise la case initiale
	if (map[x*sizeMap + y] == Plain)
	{
		tabRes[x*sizeMap + y] = CASE_OPTIMALE;
	}
	else if (map[x*sizeMap + y] == Desert)
	{
		tabRes[x*sizeMap + y] = CASE_POSSIBLE_2;
	}
	else if (map[x*sizeMap + y] == Swamp)
	{
		tabRes[x*sizeMap + y] = CASE_POSSIBLE_1;
	}
	else if (map[x*sizeMap + y] == Volcano)
	{
		tabRes[x*sizeMap + y] = CASE_POSSIBLE_0;
	}
	tabCost[x*sizeMap + y] = *movePoints;


	moveCentaur(map, sizeMap, x, y, tabRes, tabCost);
}

void Algo::moveCentaur(TileType map[], int sizeMap, int x, int y, int tabRes[], double tabMoves[])
{
	//case au dessus
	if (x != 0)
	{
		if (tabRes[(x - 1)*sizeMap + y] == CASE_NONCALCULEE)
		{
			moveCentaurTile(map, sizeMap, x - 1, y, tabRes, tabMoves, &tabMoves[x*sizeMap + y]);
		}
	}

	//case à droite
	if (y != (sizeMap - 1))
	{
		if (tabRes[x*sizeMap + y + 1] == CASE_NONCALCULEE)
		{
			moveCentaurTile(map, sizeMap, x, y + 1, tabRes, tabMoves, &tabMoves[x*sizeMap + y]);
		}
	}

	//case au dessous
	if (x != (sizeMap - 1))
	{
		if (tabRes[(x + 1)*sizeMap + y] == CASE_NONCALCULEE)
		{
			moveCentaurTile(map, sizeMap, x + 1, y, tabRes, tabMoves, &tabMoves[x*sizeMap + y]);
		}
	}

	//case à gauche
	if (y != 0)
	{
		if (tabRes[x*sizeMap + y - 1] == CASE_NONCALCULEE)
		{
			moveCentaurTile(map, sizeMap, x, y - 1, tabRes, tabMoves, &tabMoves[x*sizeMap + y]);
		}
	}
}

void Algo::moveCentaurTile(TileType map[], int sizeMap, int x, int y, int tabRes[], double tabMoves[], double * movePoints)
{
	double *movePt = movePoints;

	if (map[x*sizeMap + y] == Desert){
		if (*movePt >= 1)
		{
			*movePt--;
			tabRes[x*sizeMap + y] = CASE_POSSIBLE;
			tabMoves[x*sizeMap + y] = std::max(*movePt, tabMoves[x*sizeMap + y]);
		}
		else
		{
			tabRes[x*sizeMap + y] = CASE_IMPOSSIBLE;
		}
	}
	else if (map[x*sizeMap + y] == Desert){
		if (*movePt >= 1)
		{
			*movePt--;
			tabRes[x*sizeMap + y] = CASE_POSSIBLE;
			tabMoves[x*sizeMap + y] = std::max(*movePt, tabMoves[x*sizeMap + y]);
		}
		else
		{
			tabRes[x*sizeMap + y] = CASE_IMPOSSIBLE;
		}
	}
	else if (map[x*sizeMap + y] == Swamp){
		if (*movePt >= 1)
		{
			*movePt--;
			tabRes[x*sizeMap + y] = CASE_POSSIBLE;
			tabMoves[x*sizeMap + y] = std::max(*movePt, tabMoves[x*sizeMap + y]);
		}
		else
		{
			tabRes[x*sizeMap + y] = CASE_IMPOSSIBLE;
		}
	}
	else if (map[x*sizeMap + y] == Plain){
		if (*movePt >= 0.5)
		{
			*movePt -= 0.5;
			tabRes[x*sizeMap + y] = CASE_OPTIMALE;
			tabMoves[x*sizeMap + y] = std::max(*movePt, tabMoves[x*sizeMap + y]);
		}
		else
		{
			tabRes[x*sizeMap + y] = CASE_NONCALCULEE;
		}

	}
}

void Algo::moveCyclopInitial(TileType map[], int sizeMap, int x, int y, double tabCost[], int tabRes[], double * movePoints)
{
	//Par défaut toute les cases sont inacessibles
	int i, j;
	for (i = 0; i < sizeMap; i++)
	{
		for (j = 0; j < sizeMap; j++)
		{
			tabRes[i*sizeMap + j] = CASE_NONCALCULEE;
		}
	}

	//Les points de déplacements restants sont initialisés à 0
	for (i = 0; i < sizeMap; i++)
	{
		for (j = 0; j < sizeMap; j++)
		{
			tabCost[i*sizeMap + j] = 0;
		}
	}

	//On autorise la case initiale
	if (map[x*sizeMap + y] == Desert)
	{
		tabRes[x*sizeMap + y] = CASE_OPTIMALE;
	}
	else if (map[x*sizeMap + y] == Plain)
	{
		tabRes[x*sizeMap + y] = CASE_POSSIBLE_2;
	}
	else if (map[x*sizeMap + y] == Volcano)
	{
		tabRes[x*sizeMap + y] = CASE_POSSIBLE_1;
	}
	else if (map[x*sizeMap + y] == Swamp)
	{
		tabRes[x*sizeMap + y] = CASE_POSSIBLE_0;
	}
	tabCost[x*sizeMap + y] = *movePoints;


	moveCyclop(map, sizeMap, x, y, tabRes, tabCost);
}

void Algo::moveCyclop(TileType map[], int sizeMap, int x, int y, int tabRes[], double tabMoves[])
{
	//case au dessus
	if (x != 0)
	{
		if (tabRes[(x - 1)*sizeMap + y] == CASE_NONCALCULEE)
		{
			moveCyclopTile(map, sizeMap, x - 1, y, tabRes, tabMoves, &tabMoves[x*sizeMap + y]);
		}
	}

	//case à droite
	if (y != (sizeMap - 1))
	{
		if (tabRes[x*sizeMap + y + 1] == CASE_NONCALCULEE)
		{
			moveCyclopTile(map, sizeMap, x, y + 1, tabRes, tabMoves, &tabMoves[x*sizeMap + y]);
		}
	}

	//case au dessous
	if (x != (sizeMap - 1))
	{
		if (tabRes[(x + 1)*sizeMap + y] == CASE_NONCALCULEE)
		{
			moveCyclopTile(map, sizeMap, x + 1, y, tabRes, tabMoves, &tabMoves[x*sizeMap + y]);
		}
	}

	//case à gauche
	if (y != 0)
	{
		if (tabRes[x*sizeMap + y - 1] == CASE_NONCALCULEE)
		{
			moveCyclopTile(map, sizeMap, x, y - 1, tabRes, tabMoves, &tabMoves[x*sizeMap + y]);
		}
	}
}

void Algo::moveCyclopTile(TileType map[], int sizeMap, int x, int y, int tabRes[], double tabMoves[], double * movePoints)
{
	double *movePt = movePoints;

	if (map[x*sizeMap + y] == Desert){
		if (*movePt >= 1)
		{
			*movePt--;
			tabRes[x*sizeMap + y] = CASE_OPTIMALE;
			tabMoves[x*sizeMap + y] = *movePt;
		}
		else
		{
			tabRes[x*sizeMap + y] = CASE_IMPOSSIBLE;
		}
	}
	else if (map[x*sizeMap + y] == Plain){
		if (*movePt >= 1)
		{
			*movePt--;
			tabRes[x*sizeMap + y] = CASE_POSSIBLE;
			tabMoves[x*sizeMap + y] = *movePt;
		}
		else
		{
			tabRes[x*sizeMap + y] = CASE_IMPOSSIBLE;
		}
	}
	else if (map[x*sizeMap + y] == Volcano){
		if (*movePt >= 1)
		{
			movePt--;
			tabRes[x*sizeMap + y] = CASE_POSSIBLE;
			tabMoves[x*sizeMap + y] = *movePt;
		}
		else
		{
			tabRes[x*sizeMap + y] = 1;
		}
	}
	else if (map[x*sizeMap + y] == Swamp){
		if (*movePt >= 1)
		{
			movePt--;
			tabRes[x*sizeMap + y] = CASE_POSSIBLE;
			tabMoves[x*sizeMap + y] = *movePt;
		}
		else
		{
			tabRes[x*sizeMap + y] = CASE_IMPOSSIBLE;
		}
	}
}*/