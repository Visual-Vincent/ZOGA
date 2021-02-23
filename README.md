## Description
ZOGA (**Z**andronum **O**penGL **G**amma **A**djuster) is a small tool that helps you adjust the gamma correction level of your monitor(s) while running Zandronum using the OpenGL renderer.

On Windows 10 there is an issue that causes the gamma correction setting to fail when running Zandronum using the OpenGL renderer _and_ having multiple monitors connected to your PC. This application uses a workaround to be able to set the gamma correction successfully.

## How to use

1. Start the ZOGA
2. Set the Gamma correction to a value of your choice
3. Start Zandronum (and leave ZOGA open while you play)
4. Close ZOGA when you quit Zandronum

## Credits
**Visual Vincent**<br/>
Author

**Zalewa**<br/>
For finding the workaround using `CreateDC` instead of `GetDC` to retrieve the monitor's device context
