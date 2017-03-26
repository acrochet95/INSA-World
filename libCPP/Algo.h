#pragma once

#define CASE_NONCALCULEE -1
#define CASE_POSSIBLE_0 0
#define CASE_POSSIBLE_1 1
#define CASE_POSSIBLE_2 2
#define CASE_OPTIMALE 3 
#define CASE_POSSIBLE 4
#define CASE_IMPOSSIBLE 4

const int NB_TILETYPES = 4;


enum TileType {
	Plain = 0,
	Desert = 1,
	Volcano = 2,
	Swamp = 3
};

class Algo {

public:
	Algo();
	~Algo();

	void fillMap(TileType map[], int size);
	void positionUnits(int positions[], int size);
	void possibleMoves(TileType map[], char* race, int sizeMap, int x, int y, double * movePoints);
	/*void moveCerberusInitial(TileType map[], int sizeMap, int x, int y, double tabCost[], int tabRes[], double * movePoints);
	void moveCerberus(TileType map[], int sizeMap, int x, int y, int tabRes[], double tabMoves[]);
	void moveCerberusTile(TileType map[], int sizeMap, int x, int y, int tabRes[], double tabMoves[], double * movePoints);

	void moveCentaurInitial(TileType map[], int sizeMap, int x, int y, double tabCost[], int tabRes[], double * movePoints);
	void moveCentaur(TileType map[], int sizeMap, int x, int y, int tabRes[], double tabMoves[]);
	void moveCentaurTile(TileType map[], int sizeMap, int x, int y, int tabRes[], double tabMoves[], double * movePoints);
	void moveCyclopInitial(TileType map[], int sizeMap, int x, int y, double tabCost[], int tabRes[], double * movePoints);
	void moveCyclop(TileType map[], int sizeMap, int x, int y, int tabRes[], double tabMoves[]);
	void moveCyclopTile(TileType map[], int sizeMap, int x, int y, int tabRes[], double tabMoves[], double * movePoints);*/
};


#define EXPORTCDECL extern "C" __declspec(dllexport)
//
// export all C++ class/methods as friendly C functions to be consumed by external component in a portable way
///

EXPORTCDECL void Algo_fillMap(Algo* algo, TileType map[], int size) {
	return algo->fillMap(map, size);
}

EXPORTCDECL void Algo_positionUnits(Algo* algo, int positions[], int size) {
	return algo->positionUnits(positions, size);
}

EXPORTCDECL void Algo_possibleMoves(Algo* algo, TileType map[], char* race, int sizeMap, int x, int y, double * movePoints) {
	return algo->possibleMoves(map, race, sizeMap, x, y,  movePoints);
}

EXPORTCDECL Algo* Algo_new() {
	return new Algo();
}

EXPORTCDECL void Algo_delete(Algo* algo) {
	delete algo;
}
