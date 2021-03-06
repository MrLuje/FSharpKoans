# Functional Koans - F# #

Inspired by EdgeCase's fantastic [Ruby koans](http://github.com/edgecase/ruby_koans),
the goal of the F# koans is to teach you F# through testing.

When you first run the koans, you'll be presented with a runtime error and a
stack trace indicating where the error occured. Your goal is to make the
error go away. As you fix each error, you should learn something about
the F# language and functional programming in general.

Your journey towards F# enlightenment starts in the AboutAsserts.fs file. These
koans will be very simple, so don't overthink them! As you progress through
more koans, more and more F# syntax will be introduced which will allow
you to solve more complicated problems and use more advanced techniques.


### Getting Started

The F# Koans currently target Visual Studio 2015.

*NOTE: [NuGet](http://nuget.org/) is required to properly resolve dependencies.*

### Running the Koans in Visual Studio

1. Open the Visual Studio project, right click on the "FSharpKoans" project in the solution explorer 
   and select "Set as StartUp Project".

2. Turn off User-unhandled Exceptions. Go to Debug|Exceptions and uncheck the User-unhandled box 
   from the Common Language Runtime Exceptions item.

3. From a cmd shell, launch **run.bat** (This will resolve dependencies and watch the source folder)

You can now start fixing the koans, they will be re-evaluated on each save.
