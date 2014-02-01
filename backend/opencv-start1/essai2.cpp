/*
//OpenCV basics + GUI

#include <opencv\highgui.h>
#include <opencv\cxcore.h>
#include <opencv\cv.h>
//C
#include <stdio.h>
//C++
#include <iostream>
#include <sstream>

using namespace cv;
using namespace std;

char key;

int main(int argc, char* argv[])
{
	while(key != 'q'){
	IplImage *img = cvLoadImage("test1.png");
	Mat imgwin(img);
		
	cvNamedWindow("Essai", CV_WINDOW_AUTOSIZE);
	imshow("window", imgwin);

	IplImage *mask;
mask = cvCreateImage(cvGetSize(img), img->depth, 3);

//cvInRangeS(img, cvScalar(20, 100, 100), cvScalar(30, 255, 255), mask);

cvInRangeS(img, cvScalar(255, 255, 0), cvScalar(255, 0, 0), mask);

cvNot(mask, mask);

IplImage *imgsortie;
imgsortie = cvCreateImage(cvGetSize(img), img->depth, 3);

cvCopy(img, imgsortie, mask);

Mat imagesortie(imgsortie);

cvSaveImage("sortie5.png", imgsortie);

	key = waitKey(3000);

	cout << "Ok";
}
}

*/