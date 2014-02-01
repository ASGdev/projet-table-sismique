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

	//
	IplImage* imgHSV = cvCreateImage(cvGetSize(img), 8, 3);
    cvCvtColor(img, imgHSV, CV_BGR2HSV);

	//
	IplImage* imgThreshed = cvCreateImage(cvGetSize(img), 8, 1);
	cvInRangeS(imgHSV, cvScalar(20, 100, 100), cvScalar(30, 255, 255), imgThreshed);

	cvReleaseImage(&imgHSV);
	
cvSaveImage("sortie5.png", imgThreshed);

	key = waitKey(3000);

	cout << "Ok";
}
}
*/