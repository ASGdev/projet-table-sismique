/*
using namespace std;
using namespace cv;


int main()
{
	CvCapture* capture = cvCaptureFromCAM(CV_CAP_ANY);
		
	Size size2 = Size(640, 480);
	int codec = CV_FOURCC('M', 'J', 'P', 'G');

	CvVideoWriter* writer = cvCreateVideoWriter("videovid.avi", codec, 30, size2, true);

	int a = 1000;

while(a > 0){ //Create infinte loop for live streaming
	
	IplImage* frame = cvQueryFrame(capture);
	cvWriteToAVI(writer, frame);
	a--;
	cvShowImage("Sortie", frame);
	cvWaitKey(5);
	cout << a <<endl;
	}

    cvReleaseVideoWriter(&writer);
	cvReleaseCapture(&capture);
	return 0;
}

*/