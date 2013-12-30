/*
cout << "coucou" <<endl;
int i = 0;
while(i<500)
{
	cout << "coucou" <<endl;
	i++;
}

IplImage *essaiimage;
essaiimage = cvvLoadImage("image.jpg");

while(i<1000)
{
	cout << "Ici" <<endl;
	i++;
}

IplImage *mask;
mask = cvCreateImage(cvGetSize(essaiimage), essaiimage->depth, 1);

cvInRangeS(essaiimage, 
		   cvScalar(125.0, 0.0, 0.0),
		   cvScalar(255.0, 127.0, 127.0),
		   mask
		   );

while(i<3000)
{
	cout << "boubouboubouboubouboubou" <<endl;
	i++;
}


cvNot(mask, mask);

IplImage *imgsortie;
imgsortie = cvCreateImage(cvGetSize(essaiimage), essaiimage->depth, essaiimage->nChannels);

cvCopy(essaiimage, imgsortie, mask);

Mat imagesortie(imgsortie);

imwrite("sortie.jpg", imagesortie);

*/