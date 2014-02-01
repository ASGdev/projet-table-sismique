/*
#include <opencv/cv.h>
#include <opencv/highgui.h>

using namespace std;
using namespace cv;
char key;
double flo;
int main()
{
cvNamedWindow("Camera_Output"); //Create window
CvCapture* capture = cvCaptureFromCAM(1); //Capture using any camera connected to your system

double width = cvGetCaptureProperty(capture, CV_CAP_PROP_FRAME_WIDTH);
double height = cvGetCaptureProperty(capture, CV_CAP_PROP_FRAME_HEIGHT);
printf("[i] %.0f x %.0f\n", width, height );

while(1){ //Create infinte loop for live streaming
IplImage* frame = cvQueryFrame(capture); //Create image frames from capture
flo = cvGetCaptureProperty(capture, CV_CAP_PROP_POS_MSEC);
cvShowImage("Camera_Output", frame); //Show image frames on created window


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