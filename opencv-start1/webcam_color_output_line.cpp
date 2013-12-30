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
cvNamedWindow("Camera_Output"); //Create window
CvCapture* capture = cvCaptureFromCAM(1); //Capture using any camera connected to your system

double width = cvGetCaptureProperty(capture, CV_CAP_PROP_FRAME_WIDTH);
double height = cvGetCaptureProperty(capture, CV_CAP_PROP_FRAME_HEIGHT);
printf("%.0f x %.0f\n", width, height );

while(1){ //Create infinte loop for live streaming

	
	IplImage* frame = cvQueryFrame(capture); //Create image frames from capture
	//cvShowImage("Camera_Output", frame); //Show image frames on created window
	
	cvWaitKey(1000);
	
	  cout << "Capture" <<endl;

	IplImage* frame2 = cvQueryFrame(capture);  	
	IplImage* imgHSV = cvCreateImage(cvGetSize(frame2), 8, 3);
    cvCvtColor(frame2, imgHSV, CV_BGR2HSV);
	cvShowImage("HSV", imgHSV);
	
	IplImage* imgThreshed = cvCreateImage(cvGetSize(frame2), 8, 1);
	//cvInRangeS(imgHSV, cvScalar(20, 100, 100), cvScalar(30, 255, 255), imgThreshed);
	//red:
	cvInRangeS(imgHSV, cvScalar(170, 160, 60), cvScalar(180, 256, 256), imgThreshed);
	//cvShowImage("bin", imgThreshed);
	//cvWaitKey(500);

	//use cvnot ?

	//dessin ligne
	double ligne = (height / 6) * 5;
	double lignebas = (height / 6);

	cout << ligne <<endl;
	cout << lignebas <<endl;

	Point d;
	d.x = 0;
	d.y = ligne;
	Point f;
	f.x = width;
	f.y = ligne;
	

	Point g;
	g.x = 0;
	g.y = lignebas;
	Point h;
	h.x = width ;
	h.y = lignebas;

	cvDrawLine(frame, d, f, Scalar(128, 255, 128), 1, 8);
	
	cvShowImage("Camera_Output", frame); //Show image frames on created window

	//
	cvDrawLine(imgThreshed, d, f, Scalar(128, 255, 128), 1, 8);
	cvDrawLine(imgThreshed, g, h, Scalar(128, 255, 128), 1, 8);
	cvShowImage("bin", imgThreshed);






	 cout << "Traité" <<endl;

	  std::string strTest ("sortie-webcam.png");

	  const char* pszConstString = strTest.c_str ();

	  cvSaveImage(pszConstString, frame);
	  cvSaveImage("sortie-webcam-tres.png", imgThreshed);
	  

key = cvWaitKey(5); //Capture Keyboard stroke

cout << flo <<endl;

if (char(key) == 27){
break; //If you hit ESC key loop will break.
}
}
cvReleaseCapture(&capture); //Release capture.
cvDestroyWindow("Camera_Output"); //Destroy Window
return 0;
}
*/