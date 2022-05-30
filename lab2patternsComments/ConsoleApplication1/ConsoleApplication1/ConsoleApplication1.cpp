#include "stdafx.h"
#include <iostream>
#include <vector>
using namespace std;
// Абстрактные базовые классы всех возможных видов мебели
class Chair
{
public:
	virtual void info() = 0; // чистая виртуальная функция (т.е. неопред в данном классе, должна быть переопределна в произв классе,
	//или он тоже будет абстрактным), она делает класс в котром определена абстрактным.
	// Классы с чисто виртуальными функциями используются, в основном, в качестве интерфейсов (т.е. содержат только функции), 
	//для того чтобы наследовать от них другие классы.
	virtual ~Chair() {} //деструктор
};
class Sofa
{
public:
	virtual void info() = 0;
	virtual ~Sofa() {}
};
class Table
{
public:
	virtual void info() = 0;
	virtual ~Table() {}
};


// Классы всех видов мебели в викторианском стиле
// наследование от класса Chair, в котром переопределяем функцию info
class VictorianChair : public Chair
{
public:
	void info() {
		cout << "VictorianChair" << endl;
	}
};
class VictorianSofa : public Sofa
{
public:
	void info() {
		cout << "VictorianSofa" << endl;
	}
};
class VictorianTable : public Table
{
public:
	void info() {
		cout << "VictorianTable" << endl;
	}
};


// Классы всех видов мебели в стиле ампир
class AmpirChair : public Chair
{
public:
	void info() {
		cout << "AmpirChair" << endl;
	}
};
class AmpirSofa : public Sofa
{
public:
	void info() {
		cout << "AmpirSofa" << endl;
	}
};
class AmpirTable : public Table {
	public
		:
			void info() {
				cout << "AmpirTable" << endl;
			}
};

// Классы всех видов мебели в стиле модерн
class ModernChair : public Chair
{
public:
	void info() {
		cout << "ModernChair" << endl;
	}
};
class ModernSofa : public Sofa
{
public:
	void info() {
		cout << "ModernSofa" << endl;
	}
};
class ModernTable : public Table {
	public
		:
			void info() {
				cout << "ModernTable" << endl;
			}
};


// Абстрактная фабрика для производства мебели
class FurnitureFactory {
	public
		:
			virtual Chair* createChair() = 0; // Виртуальный базовый класс — это класс, объект которого является общим для использования всеми дочерними классами.
			virtual Sofa* createSofa() = 0;
			virtual Table* createTable() = 0;
			virtual ~FurnitureFactory() {}
};
// Фабрика для создания мебели в викторианском стиле
class VictorianFactory : public FurnitureFactory {
	public
		:
			Chair* createChair() {
				return new VictorianChair
					;
			}
			Sofa* createSofa() {
				return new VictorianSofa
					;
			}
			Table* createTable() {
				return new VictorianTable;
			}
};
// Фабрика для создания мебели в стиле Ампир
class AmpirFactory : public FurnitureFactory {
	public
		:
			Chair* createChair() {
				return new AmpirChair
					;
			}
			Sofa* createSofa() {
				return new AmpirSofa
					;
			}
			Table* createTable() {
				return new AmpirTable
					;
			}
};

// Фабрика для создания мебели в стиле Модерн
class ModernFactory : public FurnitureFactory {
	public
		:
			Chair* createChair() {
				return new ModernChair
					;
			}
			Sofa* createSofa() {
				return new ModernSofa
					;
			}
			Table* createTable() {
				return new ModernTable
					;
			}
};

// Класс, содержащий всю мебель того или иного типа
class Furniture
{
public:
	~Furniture() {
		int i;
		for (i = 0; i < vc.size(); ++i) delete vc[i];
		for (i = 0; i < vs.size(); ++i) delete vs[i];
		for (i = 0; i < vt.size(); ++i) delete vt[i];
	}
	void info() {
		int i;
		for (i = 0; i < vc.size(); ++i) vc[i]->info();
		for (i = 0; i < vs.size(); ++i) vs[i]->info();
		for (i = 0; i < vt.size(); ++i) vt[i]->info();
	}
	vector<Chair*> vc; // тип вектора Љласс, храним экземплЯры класса (указатель типа Chair)
	vector<Sofa*> vs;
	vector<Table*> vt;
};
// Здесь создается мебель того или иного типа
class AllFurniture
{
public:
	Furniture* createFurniture(FurnitureFactory& factory) {
		Furniture* p = new Furniture;
		p->vc.push_back(factory.createChair());
		p->vs.push_back(factory.createSofa());
		p->vt.push_back(factory.createTable());
		return p;
	}
};
int main()
{
    AllFurniture allFurniture;
	VictorianFactory vf_factory;
	AmpirFactory af_factory;
	ModernFactory mf_factory;
	Furniture * vf = allFurniture.createFurniture(vf_factory);
	Furniture * af = allFurniture.createFurniture(af_factory);
	Furniture * mf = allFurniture.createFurniture(mf_factory);
	cout << "Victorian furniture:" << endl;
	vf->info();
	cout << "\nAmpir furniture:" << endl;
	af->info();
	cout << "\nModern furniture:" << endl;
	mf->info();
	system("pause");
}

