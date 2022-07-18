#include <iostream>
#include <string>
#include <fstream>
using namespace std;

class Produs {
protected:
	int id_unic;
	string nume;
	string descriere;
	float discount;
	float pret;
public:
	Produs(int id = 1000, string n = "No name", string des = "NULL", float disc = 0.0, float p = 0)
	{
		if (id >= 1000)
			id_unic = id;
		else
			cout << "Id-ul nu poate fi mai mic decat 1000\t";


		if (size(n) >= 2)
			nume = n;
		else
			cout << "Nume eronat\t";


		if (size(des) >= 2)
			descriere = des;
		else
			cout << "Nu are descriere\t";


		if (disc >= 0)
			discount = disc;
		else
			cout << "Nu exista discount negativ\t";


		if (p >= 0)
			pret = p;
		else
			cout << "Nu exista pret negativ\t";

	}

	int getID()
	{
		return id_unic;
	}

	void setID(int id)
	{
		id_unic = id;
	}

	string getNume()
	{
		return nume;
	}

	void setNume(string n)
	{
		nume = n;
	}

	string getDescriere()
	{
		return descriere;
	}

	void setDescriere(string desc)
	{
		descriere = desc;
	}

	float getDiscount()
	{
		return discount;
	}

	void setDiscount(float disc)
	{
		discount = disc;
	}

	float getPret()
	{
		return pret;
	}

	void setPret(float p)
	{
		pret = p;
	}

	bool operator==(Produs& p)
	{
		if (id_unic == p.id_unic)
			return true;
		return false;
	}

	friend ostream& operator<<(ostream& os, Produs& p)
	{
		if (p.id_unic >= 1000)
			os << "Id: " << p.id_unic;
		if (size(p.nume) >= 2)
			os << "    Nume: " << p.nume;
		if (size(p.descriere) >= 2)
			os << "    Descriere: " << p.descriere;
		if (p.discount >= 0)
			os << "    Discount: " << p.discount;
		if (p.pret >= 0)
			os << "    Pret: " << p.pret << "\t";
		return os;
	}

	virtual double pretNou() = 0;

};


class Comanda : public Produs {
	int id_stare;
	int nrAlocat = 0;
	int nrOcupat = 0;
	Produs** vectPointProd = nullptr;
	static int nrComanda;
public:

	Comanda(int id_s, int nrA = 0) : nrAlocat(nrA), nrOcupat(0), id_stare(id_s)
	{

		nrComanda++;
		if (nrAlocat > 0)
		{
			vectPointProd = new Produs * [nrAlocat];
			for (int i = 0; i < nrAlocat; i++) vectPointProd[i] = nullptr;
		}
	}

	Comanda(int id_s, int nrO, Produs* vPP[]) : nrOcupat(nrO), nrAlocat(nrO), id_stare(id_s)
	{
		nrComanda++;
		vectPointProd = new Produs * [nrAlocat];
		for (int i = 0; i < nrOcupat; i++)
			vectPointProd[i] = *new Produs * (vPP[i]);
	}
	~Comanda()
	{
		delete[] this->vectPointProd;
	}

	Comanda& operator+=(Produs& p) //adaugare produs in comanbda
	{
		cout << "Produsul a fost adaugat in comanda\n";
		if (nrOcupat > 0) {
			Produs** aux = new Produs * [this->nrOcupat];   //Salvare vector curent
			for (int i = 0; i < this->nrOcupat; i++)
				aux[i] = *new Produs * (vectPointProd[i]);

			this->nrOcupat++;

			delete[] this->vectPointProd;   //Stergere vector curent
			this->vectPointProd = new Produs * [this->nrOcupat]; //Redimensionare vector curent
			for (int i = 0; i < this->nrOcupat - 1; i++)  // Copiere valori in vectorul curent 
				this->vectPointProd[i] = *new Produs * (aux[i]);

			this->vectPointProd[this->nrOcupat - 1] = *new Produs * (&p);   //Adaugare produs nou in comanda

			delete[] aux; //Stergere aux 
		}
		else {
			this->nrOcupat++;
			this->vectPointProd = new Produs * [1];
			this->vectPointProd[0] = *new Produs * (&p);
		}

		return *this;
	}

	Comanda& operator-=(Produs& p) //stergere produs din comanda
	{
		cout << "Produsul a fost sters din comanda\n";
		Produs** aux = new Produs * [this->nrOcupat];
		for (int i = 0; i < this->nrOcupat; i++) {
			aux[i] = *new Produs * (this->vectPointProd[i]);
		}

		for (int i = 0; i < this->nrOcupat; i++) {
			if (*aux[i] == p) {  //Daca este identic cu produsul cautat, il stergem din vector
				for (int j = i; j < this->nrOcupat - 1; j++) aux[j] = aux[j + 1];
				this->nrOcupat--;
				break; //L-am gasit, deci oprim for-ul
			}
		}

		delete[] this->vectPointProd;
		this->vectPointProd = new Produs * [this->nrOcupat];
		for (int i = 0; i < this->nrOcupat; i++)
			this->vectPointProd[i] = *new Produs * (aux[i]);

		delete[] aux;
		return *this;
	}

	double pretNou()
	{
		double pret_nou = pret - pret * discount;
		cout << "\nPret nou comanda: ";
		return pret_nou;
	}

	friend ofstream& operator<<(ofstream& os, Comanda& c)
	{
		if (c.id_stare == 1)
			os << "\nComanda " << c.nrComanda << " neplasata";

		if (c.id_stare == 2)
			os << "\nComanda " << c.nrComanda << " in procesare";

		if (c.id_stare == 3)
			os << "\nComanda " << c.nrComanda << " livrata";

		os << "\nContinutul comenzii " << c.nrComanda << " care contine " << c.nrOcupat << " produs(e): " << endl;
		os << "---------------------------------------------------------------------------------------------------------------------------------------------------------";
		for (int i = 0; i < c.nrOcupat; i++)
			os << "\n" << *c.vectPointProd[i];
		os << endl << endl;
		return os;
	}
};
int Comanda::nrComanda = 0;

class Laptopuri :public Produs {
	string brand;
	string categorie;
	string sistem_operare;
	float dimensiune;
public:
	Laptopuri(int id = 1000, string n = "Laptop", string des = "Calculator portabil", float disc = 0.1, float p = 1000, string b = "Asus", string c = "Gaming", string s = "Windows", float dim = 15.9) : Produs(id, n, des, disc, p)
	{
		brand = b;
		categorie = c;
		dimensiune = dim;
		sistem_operare = s;
	}

	double pretNou()
	{
		double pret_nou = pret - pret * discount;
		cout << "\nPret nou laptop: ";
		return pret_nou;
	}

	friend ostream& operator<<(ostream& os, Laptopuri& l)
	{
		os << (Produs&)l; // partea mostenita
		os << "\tBrand: " << l.brand
			<< "\t\tCategorie: " << l.categorie << "\tSistem de operare: " << l.sistem_operare << "\tDimensiune: " << l.dimensiune;
		return os;
	}
};

class Monitoare :public Produs {
	int rata_refresh;
	string tip_ecran;
	float dimensiune;
	string rezolutie;
public:
	Monitoare(int id = 2000, string n = "Monitor", string des = "Periferic de iesire", float disc = 0.15, float p = 1400, float dim = 31.5, int rata = 240, string t = "Curbat", string rez = "3840 X 2160") : Produs(id, n, des, disc, p)
	{
		dimensiune = dim;
		rata_refresh = rata;
		tip_ecran = t;
		rezolutie = rez;
	}

	double pretNou()
	{
		double pret_nou = pret - pret * discount;
		/*cout << "Pret nou monitor: ";*/
		return pret_nou;
	}

	friend ostream& operator<<(ostream& os, Monitoare& m)
	{
		os << (Produs&)m; // partea mostenita
		os << "\tDimensiune: " << m.dimensiune
			<< "\t\tRata refresh: " << m.rata_refresh << "\tTip ecran: " << m.tip_ecran << "\tRezolutie: " << m.rezolutie;
		return os;
	}
};

class Casti :public Produs {
	string tehnologie;
	string culoare;
	float lungime_cablu;
public:
	Casti(int id = 3000, string n = "Casti", string des = "Dispozitive electrice pentru receptia si ascultarea sunetelor si muzicii", float disc = 0.2, float p = 800, string t = "Wireless", string c = "Alb", float l = 0) : Produs(id, n, des, disc, p)
	{
		tehnologie = t;
		culoare = c;
		lungime_cablu = l;
	}

	double pretNou()
	{
		double pret_nou = pret - pret * discount;
		cout << "\nPret nou casti: ";
		return pret_nou;
	}

	friend ostream& operator<<(ostream& os, Casti& c)
	{
		os << (Produs&)c; // partea mostenita
		os << "\tTehnologie: " << c.tehnologie
			<< "\t\tCuloare: " << c.culoare << "\tLungime cablu: " << c.lungime_cablu;
		return os;
	}
};

class BoxePortabile :public Produs {
	string conexiune;
	string functii;
	string autonomie;
public:
	BoxePortabile(int id = 4000, string n = "Boxa portabila", string des = "Dispozitiv de iesire care reda continut audio", float disc = 0.25, float p = 1500, string c = "Bluetooth", string f = "Rezistent la apa", string a = "20 ore") : Produs(id, n, des, disc, p)
	{
		conexiune = c;
		functii = f;
		autonomie = a;
	}

	double pretNou()
	{
		double pret_nou = pret - pret * discount;
		cout << "\nPret nou boxa portabila: ";
		return pret_nou;
	}

	friend ostream& operator<<(ostream& os, BoxePortabile& b)
	{
		os << (Produs&)b; // partea mostenita
		os << "\tConexiune: " << b.conexiune
			<< "\t\tFunctii: " << b.functii << "\tAutonomie: " << b.autonomie;
		return os;
	}
};



int main()
{
	Monitoare m1;
	BoxePortabile b1;
	Laptopuri l1;
	Casti c1;
	cout << "EXEMPLIFICAREA FUNCTIILOR DE AFISARE A OBIECTELOR" << endl;
	cout << m1;
	cout << endl << b1;
	cout << endl << endl << "EXEMPLIFICAREA FUNCTIONALITATII GET-ERILOR SI SET-ERILOR";
	cout << endl << "Denumirea " << m1.getNume();
	m1.setNume("Ecran");
	cout << " se va transforma in " << m1.getNume();
	cout << endl << m1 << endl;
	cout << endl << "EXEMPLIFICAREA FUNCTIEI VIRTUALE DIN CLASA ABSTRACTA PRODUS PENTRU UN MONITOR" << endl;
	cout << "Pretul vechi al monitorului: " << m1.getPret() << " inmultit cu discountul de: " << m1.getDiscount() << " = pretul nou al monitorului: " << m1.pretNou() << endl;
	cout << "\nEXEMPLIFICAREA FUNCTIONALITATII OPERATORULUI ==";
	if (m1 == b1)
		cout << endl << "Produsele monitor si boxe sunt identice\n";
	else
		cout << endl << "Produsele monitor si boxe sunt diferite\n";
	ofstream fisOut("Comenzi.txt");
	if (!fisOut)
		cerr << "\n Esuare deschidere fisier";
	Produs* vPP[] = {
		new Monitoare,new Laptopuri,new BoxePortabile,new Casti
	};
	cout << endl;
	Comanda cp(1, 4, vPP);
	Comanda cp2(2, 10);
	cout << endl;
	cout << endl;
	cout << "----------------------------------------------------------" << "MENIU" << "-------------------------------------------------" << endl;
	cout << "----------------------------------------------------------------------------------------------------------------------------" << endl;
	cout << "LISTA PRODUSE\n";
	cout << "Produsul: " << l1.getNume() << " are id-ul " << l1.getID() << endl;
	cout << "Produsul: " << m1.getNume() << " are id-ul " << m1.getID() << endl;
	cout << "Produsul: " << c1.getNume() << " are id-ul " << c1.getID() << endl;
	cout << "Produsul: " << b1.getNume() << " are id-ul " << b1.getID() << endl;
	cout << endl;
	cout << "Introduceti id-ul produsului pe care doriti sa-l adaugati in comanda:";
	int nr = 0; int id;
	do
	{
		if (nr > 0)
		{
			cout << "\nDoriti sa adaugati alt produs sau sa stergeti un produs existent?";
			cout << "\n1.DORESC SA ADAUG\n2.NU MAI DORESC NIMIC\n3.DORESC SA STERG\n";
			int raspuns; cin >> raspuns;
			if (raspuns == 1)
				cout << "Introduceti id-ul produsului dorit: ";
			if (raspuns == 2)
				break;
			if (raspuns == 3)
			{
				int k = 1;
				while (k == 1)
				{
					cout << "Introduceti id-ul produsului pe care doriti sa-l stergeti: ";
					cin >> id;
					if (id != l1.getID() && id != m1.getID() && id != c1.getID() && id != b1.getID())
					{
						cout << "Id invalid";
						break;
						cout << "\nReintroduceti id-ul: ";
					}
					if (id == c1.getID())
					{
						cp2 -= c1;
					}
					else if (id == m1.getID())
					{
						cp2 -= m1;
					}
					else if (id == l1.getID())
					{
						cp2 -= l1;
					}
					else if (id == b1.getID())
					{
						cp2 -= b1;
					}

					cout << endl << "Doriti sa mai stergeti inca un produs?\n1.DA\n2.NU\n";
					int raspuns2;
					cin >> raspuns2;
					if (raspuns2 == 1)
						k = 1;
					if (raspuns2 == 2)
						break;
				}
				cout << endl << "Doriti sa mai adaugati alt produs?\n1.DA\n2.NU\n ";
				int input;
				cin >> input;
				if (input == 1)
					cout << "In regula, introduceti urmatorul ID: ";
				else if (input == 2)
					break;
			}
		}
		cin >> id;
		cout << endl;
		nr++;
		if (id != l1.getID() && id != m1.getID() && id != c1.getID() && id != b1.getID())
		{
			cout << "Id invalid";
			break;

		}
		if (id == c1.getID())
		{
			cp2 += c1;
		}
		if (id == m1.getID())
		{
			cp2 += m1;
		}
		if (id == l1.getID())
		{
			cp2 += l1;
		}
		if (id == b1.getID())
		{
			cp2 += b1;
		}


	} while (id == l1.getID() || id == m1.getID() || id == c1.getID() || id == b1.getID());
	fisOut << cp2;
	/*fisOut << cp;
	cp -= l1;
	fisOut  << "\nDupa stergerea laptopului din prima comanda" << endl<<endl ;
	fisOut << cp;

	fisOut << cp2;
	cp2 += c1;
	cp2 += l1;
	cp2 += m1;
	fisOut << "\nDupa adaugarea celor 3 produse in a doua comanda" << endl<<endl ;
	fisOut<<cp2;*/
	
}

