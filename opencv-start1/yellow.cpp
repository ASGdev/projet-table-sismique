/*
#include <opencv/cv.h>
#include <opencv/highgui.h>

using namespace std;
using namespace cv;
char key;
double flo;
int i = 0;
int main()
{

	IplImage *img = cvLoadImage("yellow.png");
	Mat imgwin(img);
		
	cvNamedWindow("Essai", CV_WINDOW_AUTOSIZE);
	imshow("window", imgwin);

	int i = 0;
	int j;
	CvScalar s;
	int width, height;

while(1){ //Create infinte loop for live streaming
	
while (i < 2000)
{
	width = img->width;
	height = img->height;
	printf("img : w=%i & h=%i\n", width, height);
	cvWaitKey(2000);
	//s=cvGet2D(img, i ,20); // get the (i,j) pixel value
	//printf("B=%f, G=%f, R=%f\n",s.val[0],s.val[1],s.val[2]);
	//printf("i=%i\n", i);0......
	//i++;
}

	 
key = cvWaitKey(1000); //Capture Keyboard stroke



if (char(key) == 27){
break; //If you hit ESC key loop will break.
}
}

cvDestroyWindow("Camera_Output"); //Destroy Window
return 0;
}

*/