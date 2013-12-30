/*
#include <opencv/cv.h>
#include <opencv/highgui.h>

using namespace std;
using namespace cv;
char key;
int n = 0;
int i = 0;
int y = 0;
int main()
{
	
	IplImage *img = cvLoadImage("red.png");
	
	
	int j;
	CvScalar s;
	int width, height;

	width = img->width;
	height = img->height;
	printf("img : w=%i & h=%i\n", width, height);
	
	//calcul des limites
	int limSupHaut, limSupBas, limSupGauche, limSupDroite, limInfHaut, limInfBas, limInfDroite, limInfGauche;
	//lim sup
	limSupHaut = (height / 10) * 9;
	limSupBas = (height / 10);
	limSupDroite = (width / 10) * 9;
	limSupGauche = (width / 10);
	
	Point A(0, limSupHaut);
	Point B(width, limSupHaut);
	Point C(0, limSupBas);
	Point D(width, limSupBas);
	Point E(limSupGauche, height);
	Point F(limSupGauche, 0);
	Point G(limSupDroite, width);
	Point H(limSupDroite, 0);

	cvDrawLine(img, A, B, Scalar(128, 255, 128), 1, 8);
	cvDrawLine(img, C, D, Scalar(128, 255, 128), 1, 8);
	cvDrawLine(img, E, F, Scalar(128, 255, 128), 1, 8);
	cvDrawLine(img, G, H, Scalar(128, 255, 128), 1, 8);


	//lim inf
	limInfHaut = (height / 4) * 3;
	limInfBas = (height / 4);
	limInfDroite = (width / 4) * 3;
	limInfGauche = (width / 4);
	
	Point I(0, limInfHaut);
	Point J(width, limInfHaut);
	Point K(0, limInfBas);
	Point L(width, limInfBas);
	Point M(limInfGauche, height);
	Point N(limInfGauche, 0);
	Point O(limInfDroite, height);
	Point P(limInfDroite, 0);
	
	cvDrawLine(img, I, J, Scalar(128, 255, 128), 1, 8);
	cvDrawLine(img, K, L, Scalar(128, 255, 128), 1, 8);
	cvDrawLine(img, M, N, Scalar(128, 255, 128), 1, 8);
	cvDrawLine(img, O, P, Scalar(128, 255, 128), 1, 8);


	cvShowImage("Sortie", img);


	//mumuse avec les pixels

	//partie supérieur haute
	
	
	for (int x=0; x < width; x++) //et tant que height ne depasse pas 392 (image.height)
	{
		while(y < height){
		s=cvGet2D(img, x ,y);
		printf("B=%f, V=%f, R=%f\n",s.val[0],s.val[1],s.val[2]);
		n++;
		cout << "x =" << x <<endl;
		cout << n <<endl;
		y++;
		}
		y = 0;	
		cout << "fin" <<endl;

	}

key = cvWaitKey(12000);

}
*/