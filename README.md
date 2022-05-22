# Dendro
Dendro is a volumetric modeling plug-in for Grasshopper-3D built on top of the OpenVDB library. It provides multiple ways to wrap points, curves, and meshes as a volumetric data within Grasshopper-3D, allowing you to perform various operations on those volumes. Dendro includes components for boolean, smoothing, offsets, and morphing operations. You can find out more details of its features [here](https://www.ecrlabs.com/dendro) or download a working version [here](https://www.food4rhino.com/app/dendro)

## Design

We have been using the OpenVDB library for a couple years, but needed something to prototype quicker with. We had built a rough version of this for Grasshopper-3D, but decided to package it up nicer and put a release together. Hopefully it is something to build upon and our hope was it could serve as a starting point to add more features and functionality to.

The goal was to make Dendro integrate into Grasshopper-3D as seamlessly as possible. Whereas many voxel solutions require you to think of geometry as living with a bounding box, Dendro makes working with volumes no different than handling any other geometry in Grasshopper-3D. Dendro works with many native Grasshopper-3D components, avoiding the 'blocking' found in other plugins, and allowing you to move in and out of volume operations very quickly.

## Installation

Dendro contains two projects, a C++ project for working with OpenVDB and a C# project creating the Grasshopper-3D plugin.

##### DendroAPI (C++)

C++ dependencies are installed using vcpkg on build, see [Get started with vcpkg](https://vcpkg.io/en/getting-started.html). The project are using a manifest file to list dependencies.

##### DendroGH (C#)
Since there are multiple versions of Rhino, each with their specific SDK, we added the Rhinocommon and Grasshopper-3D libraries as a nuget package in order to let you specifically target your desired Rhino version. That can be changed by `Right-clicking the C# project`, then selecting `Manage Nuget Packages`, clicking the `Installed` tab, `Selecting` your desired package, and finally, changing the `Version` in the right panel.

## Developing

Dendro is built using Microsoft Visual Studio 2022, but you should be able to re-target for other versions.

Add the folder `bin\Debug` (or `bin\Release`) to library paths for Grasshopper using `GrasshopperDeveloperSettings`.

### Formatting

C++ code should be formatted using clang-formatter (included in Visual Studio). The `Microsoft` style was selected as it seemed to be closest to existing code style. clang-formatter settings can be found in `.clang-format`

C# code is formatted according to the `.editorconfig` file.

### Git config

Add the following setting to ignore formatting commit(s) when using `git blame`.

```
git config blame.ignoreRevsFile .git-blame-ignore-revs
```

## More Info

Dendro is using OpenVDB. For more information on the library, please visit [here](http://www.openvdb.org/).